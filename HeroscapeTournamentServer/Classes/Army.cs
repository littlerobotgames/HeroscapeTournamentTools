using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HeroscapeTournamentServer.Classes
{
    public class Army
    {
        public double armyId { get; set; }
        public string name { get; set; } = "";
        public double playerId { get; set; } = 0;

        public double armyLeader { get; set; }
        public List<ArmyEntry> ArmyEntries { get; set;} = new List<ArmyEntry>();

        public void PrintArmy()
        {
            Console.WriteLine($"[{armyId}] {name}");
            Console.WriteLine($"Creator: {playerId}");
            foreach(var entry in ArmyEntries ) 
            {
                Console.WriteLine($"    [{entry.cardId}]: {entry.amount}");
            }
        }
    }
    public class ArmyEntry
    {
        public double cardId { get; set; } = 0;
        public double amount { get; set; } = 0;
    }
}
