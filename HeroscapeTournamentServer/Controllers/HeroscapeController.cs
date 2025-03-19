using HeroscapeTournamentServer.Classes;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
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
        public string DatabaseVersion = "1.0.1";

        public List<FigureCollection> collections = new List<FigureCollection>();
        public string[] Generals = { "Jandar", "Ullar", "Einar", "Vydar", "Utgar", "Aquilla", "Valkrill", "Marvel", "Revna" };
        public string[] Sizes = { "Small", "Medium", "Large", "Huge" };
        public string[] Rarity = { "Common", "Uncommon", "Unique" };
        public string[] Type = { "Squad", "Hero" };

        private string Password = "I-rolled-all-blanks";

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
        public IActionResult GetStatus()
        {
            Console.WriteLine("Got a status ping");
            return Ok();
        }
        [HttpGet("GetDatabaseVersion")]
        public string GetDatabaseVersion()
        {
            return DatabaseVersion;
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
        [HttpGet("GetAvailableFigures")]
        public FigureCollection GetAvailableFigures([FromHeader] int _tournamentId)
        {
            return GetAvailableFiguresCollection(_tournamentId);
        }
        [HttpPost("PlayerLogin")]
        public PlayerPublic PlayerLogin([FromBody] Credentials _credentials)
        {
            string _email = _credentials.Email;
            string _password = _credentials.Password;

            Console.WriteLine("Got a login request");
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
        [HttpGet("GetPlayerArmies")]
        public IEnumerable<Army> GetPlayerArmies([FromHeader] int playerId)
        {
            List<Army> TempArmies = new List<Army>();

            TempArmies = armies.Where(a => a.playerId == playerId).ToList();

            return TempArmies;
        }
        [HttpGet("TournamentCodeSubmit")]
        public bool TournamentCodeSubmit([FromHeader] int tourneyId, [FromHeader] int code)
        {
            if (tournaments.Where(t => t.id == tourneyId).FirstOrDefault().join_code == code)
            {
                return true;
            }
            else
            {
                return false;
            }
                   
        }
        [HttpPost("NewPlayer")]
        public bool NewPlayer([FromHeader] string firstname, [FromHeader] string lastname, [FromHeader] string email, [FromHeader] string password)
        {
            //Check email available
            foreach(Player p in players)
            {
                if (p.email == email)
                {
                    return false;
                }
            }

            Player tempP = new Player();
            tempP.firstname = firstname;
            tempP.lastname = lastname;
            tempP.email = email;
            tempP.password = password;

            int highestId = 0;

            foreach(Player p in players)
            {
                if (p.id > highestId)
                {
                    highestId = p.id;
                }
            }

            tempP.id = highestId + 1;

            players.Add(tempP);

            string text = JsonSerializer.Serialize(players);
            System.IO.File.WriteAllText(Root + "/gamedata/players.json", text);

            return true;
        }
        [HttpPost("NewArmy")]
        public bool NewArmy([FromBody] Army army)
        {
            int newArmyId = 0;

            foreach(Army a in armies)
            {
                if (a.id > newArmyId)
                {
                    newArmyId = a.id;
                }
            }

            army.id = newArmyId + 1;

            armies.Add(army);

            string text = JsonSerializer.Serialize(armies);
            System.IO.File.WriteAllText(Root + "/gamedata/armies.json", text);

            return true;
        }
        [HttpPost("NewTournyEntry")]
        public bool NewTournyEntry([FromHeader] int _tournamentId, [FromHeader] int _playerId, [FromHeader] int _armyId)
        {
            Console.WriteLine($"Player [{_playerId}] is entering army [{_armyId}] into tournament [{_tournamentId}]");
            //Check that the army is available
            FigureCollection tempReservedList = GetTournamentReserved(_tournamentId);
            FigureCollection tempTotalCollection = GetCombinedCollections();

            Army tempArmy = armies.Where(a => a.id == _armyId).FirstOrDefault();

            bool ok = true;

            /*
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
            */

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
        [HttpPatch("UpdateArmy")]
        public int UpdateArmy([FromBody] Army army)
        {
            if (army.id != -1)
            {
                int armyIndex = armies.FindIndex(a => a.id == army.id);
                Console.WriteLine($"Updating army [{army.id}]");
                armies[armyIndex] = army;   
            }
            else
            {
                int newArmyId = 0;

                foreach (Army a in armies)
                {
                    if (a.id > newArmyId)
                    {
                        newArmyId = a.id;
                    }
                }
                army.id = newArmyId + 1;

                Console.WriteLine($"Adding new army [{army.id}]");
                armies.Add(army);
            }

            string text = JsonSerializer.Serialize(armies);
            System.IO.File.WriteAllText(Root + "/gamedata/armies.json", text);

            return army.id;

        }
        [HttpDelete("DeleteArmy")]
        public bool DeleteArmy([FromHeader] int armyId)
        {
            int armyIndex = armies.FindIndex(a => a.id == armyId);

            if (armyIndex >= 0)
            {
                armies.RemoveAt(armyIndex);

                string text = JsonSerializer.Serialize(armies);
                System.IO.File.WriteAllText(Root + "/gamedata/armies.json", text);

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
        [ApiExplorerSettings(IgnoreApi = true)]
        public FigureCollection GetAvailableFiguresCollection(int _tournamentId)
        {
            FigureCollection totalAvailable = GetCombinedCollections();
            Tournament tournament = tournaments.Where(t => t.id == _tournamentId).FirstOrDefault();

            foreach (TournyEntry entry in tournament.entries)
            {
                foreach(ArmyEntry armyEntry in armies[entry.army].ArmyEntries)
                {
                    totalAvailable.armyEntries.Where(e => e.cardId == armyEntry.cardId).FirstOrDefault().amount -= armyEntry.amount;
                }
            }

            return totalAvailable;
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public static string DecryptString(string encrypted, string password)
        {
            // Convert the encrypted string to a byte array
            byte[] encryptedBytes = Convert.FromBase64String(encrypted);

            // Derive the password using the PBKDF2 algorithm
            Rfc2898DeriveBytes passwordBytes = new Rfc2898DeriveBytes(password, 20);

            // Use the password to decrypt the encrypted string
            Aes encryptor = Aes.Create();
            encryptor.BlockSize = 128;
            encryptor.Key = passwordBytes.GetBytes(32);
            encryptor.IV = passwordBytes.GetBytes(16);
            encryptor.Padding = PaddingMode.PKCS7;

            using MemoryStream ms = new MemoryStream();
            using CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write);

            cs.Write(encryptedBytes, 0, encryptedBytes.Length);
            cs.FlushFinalBlock();

            return Encoding.Unicode.GetString(ms.ToArray());
        }
    }
}