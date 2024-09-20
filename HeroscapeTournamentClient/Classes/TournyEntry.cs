namespace HeroscapeTournamentServer.Classes
{
    public class TournyEntry
    {
        public int playerId { get; set; } = 0;
        public int army { get; set; }
        public bool paid { get; set; } = false;
        public TournyEntry(int playerId, int army, bool paid)
        {
            this.playerId = playerId;
            this.army = army;
            this.paid = paid;
        }
    }
}
