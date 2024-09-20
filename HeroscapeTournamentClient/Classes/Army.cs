namespace HeroscapeTournamentServer.Classes
{
    public class Army
    {
        public int id { get; set; }
        public string name { get; set; } = "";
        public int playerId { get; set; } = 0;
        public List<ArmyEntry> ArmyEntries { get; set;} = new List<ArmyEntry>();

        public void PrintArmy()
        {
            Console.WriteLine($"[{id}] {name}");
            Console.WriteLine($"Creator: {playerId}");
            foreach(var entry in ArmyEntries ) 
            {
                Console.WriteLine($"    [{entry.cardId}]: {entry.amount}");
            }
        }
    }
    public class ArmyEntry
    {
        public int cardId { get; set; } = 0;
        public int amount { get; set; } = 0;
    }
}
