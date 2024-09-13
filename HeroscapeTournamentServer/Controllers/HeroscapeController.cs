using HeroscapeTournamentServer.Classes;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HeroscapeTournamentServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeroscapeController : ControllerBase
    {
        public string Root = System.IO.Path.GetFullPath(@"..\..\..\");

        public List<Set> sets;
        public List<Card> cards;
        public string[] Generals = { "Jandar", "Ullar", "Einar", "Vydar", "Utgar", "Aquilla", "Valkrill", "Marvel" };
        public string[] Sizes = { "Small", "Medium", "Large", "Huge" };
        public string[] Rarity = { "Common", "Uncommon", "Unique" };
        public string[] Type = { "Squad", "Hero" };

        private readonly ILogger<HeroscapeController> _logger;
        public HeroscapeController(ILogger<HeroscapeController> logger)
        {
            _logger = logger;

            string text = File.ReadAllText(Root + "/gamedata/data_waves.json");
            sets = JsonSerializer.Deserialize<List<Set>>(text);

            text = File.ReadAllText(Root + "/gamedata/data_figures.json");
            cards = JsonSerializer.Deserialize<List<Card>>(text);
        }

        [HttpGet(Name = "GetCardDatabase")]
        public IEnumerable<Card> Get()
        {
            return cards;
        }
    }
}