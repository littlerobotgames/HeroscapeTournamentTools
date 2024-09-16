using HeroscapeTournamentServer.Classes;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace HeroscapeTournamentServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeroscapeController : ControllerBase
    {
        public string Root = Environment.CurrentDirectory;
        public List<Card> cards = new List<Card>();
        public List<Set> sets = new List<Set>();
        public List<Tournament> tournaments = new List<Tournament>();
        public List<Player> players = new List<Player>();
        public List<Army> armies = new List<Army>();

        public List<FigureCollection> collections = new List<FigureCollection>();
        public string[] Generals = { "Jandar", "Ullar", "Einar", "Vydar", "Utgar", "Aquilla", "Valkrill", "Marvel" };
        public string[] Sizes = { "Small", "Medium", "Large", "Huge" };
        public string[] Rarity = { "Common", "Uncommon", "Unique" };
        public string[] Type = { "Squad", "Hero" };

        private readonly ILogger<HeroscapeController> _logger;
        public HeroscapeController(ILogger<HeroscapeController> logger)
        {
            _logger = logger;

            cards = GetFileData<Card>("/gamedata/data_figures.json");
            sets = GetFileData<Set>("/gamedata/data_waves.json");
            tournaments = GetFileData<Tournament>("/gamedata/tournaments.json");
            players = GetFileData<Player>("/gamedata/players.json");
            armies = GetFileData<Army>("/gamedata/armies.json");

            string[] files = Directory.GetFiles(Root + "/gamedata/collections", "*.json");

            foreach(string f in files)
            {
                collections.Add(
                    JsonSerializer.Deserialize<FigureCollection>(
                        System.IO.File.ReadAllText(f)
                        )
                );
            }
        }
        [HttpGet("GetStatus")]
        public int GetStatus()
        {
            return 0;
        }
        [HttpGet("GetCardDatabase")]
        public IEnumerable<Card> GetCardDatabase()
        {
            return cards;
        }
        [HttpGet("GetSetDatabase")]
        public IEnumerable<Set> GetSetDatabase()
        {
            return sets;
        }
        [HttpGet("GetTournaments")]
        public IEnumerable<Tournament> GetTournaments()
        {
            return tournaments;
        }
        [HttpGet("GetPlayer")]
        public PlayerPublic GetPlayer([FromHeader] int playerId)
        {
            return new PlayerPublic(
                players.Where(p => p.id == playerId).FirstOrDefault()
                );
        }
        [HttpGet("GetArmies")]
        public IEnumerable<Army> GetArmies()
        {
            return armies;
        }
        [HttpGet("GetArmy")]
        public Army GetArmy([FromHeader] int armyId)
        {
            return armies.Where(p =>p.id == armyId).FirstOrDefault();
        }
        [HttpGet("GetCollections")]
        public IEnumerable<FigureCollection> GetFigureCollection() 
        {
            return collections;
        }
        [HttpGet("GetTotalCollection")]
        public FigureCollection GetTotalCollection()
        {
            return GetCombinedCollections();
        }
        [HttpGet("GetReservedFigures")]
        public FigureCollection GetReservedFigures([FromHeader] int _tournamentId)
        {
            return GetTournamentReserved(_tournamentId);
        }
        [HttpGet("PlayerLogin")]
        public PlayerPublic PlayerLogin(string _email, string _password)
        {
            foreach(Player p in players)
            {
                if (p.email == _email)
                {
                    if (p.password == _password)
                    {
                        return new PlayerPublic(p);
                    }
                }
            }

            return null;
        }
        [HttpPost("NewPlayer")]
        public bool NewPlayer([FromHeader] string firstname, [FromHeader] string lastname, [FromHeader] string email, [FromHeader] string password)
        {
            Player tempP = new Player();
            tempP.firstname = firstname;
            tempP.lastname = lastname;
            tempP.email = email;
            tempP.password = password;
            tempP.id = players.Count();

            players.Add(tempP);

            string text = JsonSerializer.Serialize(players);
            System.IO.File.WriteAllText(Root + "/gamedata/players.json", text);

            return true;
        }
        [HttpPost("NewArmy")]
        public bool NewArmy([FromBody] Army army)
        {
            army.id = armies.Count();
            army.PrintArmy();

            armies.Add(army);

            string text = JsonSerializer.Serialize(armies);
            System.IO.File.WriteAllText(Root + "/gamedata/armies.json", text);

            return true;
        }
        [HttpPost("NewTournyEntry")]
        public bool NewTournyEntry([FromHeader] int _tournamentId, int _playerId, int _armyId)
        {
            //Check that the army is available
            FigureCollection tempReservedList = GetTournamentReserved(_tournamentId);
            FigureCollection tempTotalCollection = GetCombinedCollections();

            Army tempArmy = armies.Where(a => a.id == _armyId).FirstOrDefault();

            bool ok = true;
            foreach(ArmyEntry entry in tempArmy.ArmyEntries)
            {
                int amount_total = tempTotalCollection.armyEntries.Where(e => e.cardId == entry.cardId).FirstOrDefault().amount;
                int amount_reserved = tempReservedList.armyEntries.Where(e => e.cardId == entry.cardId).FirstOrDefault().amount;

                if (amount_total - amount_reserved < entry.amount)
                {
                    ok = false;
                    break;
                }
            }

            if (ok)
            {
                tournaments.Where(t => t.id == _tournamentId).FirstOrDefault().entries.Add(new TournyEntry(_playerId, _armyId, false));

                string text = JsonSerializer.Serialize(tournaments);
                System.IO.File.WriteAllText(Root + "/gamedata/tournaments.json", text);
                return true;
            }
            else
            {
                return false;
            }
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public List<T> GetFileData<T>(string path)
        {
            string text = System.IO.File.ReadAllText(Environment.CurrentDirectory + path);
            return JsonSerializer.Deserialize<List<T>>(text);
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public FigureCollection GetCombinedCollections()
        {
            //Create a collection with 0 of each card
            FigureCollection total = new FigureCollection();

            foreach (Card card in cards)
            {
                ArmyEntry temp = new ArmyEntry();
                temp.cardId = card.id;
                total.armyEntries.Add(temp);
            }
            foreach (FigureCollection collection in collections)
            {
                foreach (ArmyEntry entry in collection.armyEntries)
                {
                    total.armyEntries.Where(e => e.cardId == entry.cardId).FirstOrDefault().amount += entry.amount;
                }
            }

            return total;
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public FigureCollection GetTournamentReserved(int _tournamentId)
        {
            //Create a collection with 0 of each card
            FigureCollection total = new FigureCollection();

            foreach (Card card in cards)
            {
                ArmyEntry temp = new ArmyEntry();
                temp.cardId = card.id;
                total.armyEntries.Add(temp);
            }
            //Loop through each army entry in each army of each tournament entry
            foreach (TournyEntry entry in tournaments[_tournamentId].entries)
            {
                foreach (ArmyEntry Aentry in armies[entry.army].ArmyEntries)
                {
                    total.armyEntries.Where(e => e.cardId == Aentry.cardId).FirstOrDefault().amount += Aentry.amount;
                }
            }

            return total;
        }
    }
}