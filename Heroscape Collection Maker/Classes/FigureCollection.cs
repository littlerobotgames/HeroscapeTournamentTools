namespace HeroscapeTournamentServer.Classes
{
    public class FigureCollection
    {
        public int playerId { get; set; } = 0;
        public List<ArmyEntry> armyEntries { get; set; } = new List<ArmyEntry>();
    }
}
