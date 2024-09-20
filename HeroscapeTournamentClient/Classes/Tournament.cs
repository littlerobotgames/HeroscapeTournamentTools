namespace HeroscapeTournamentServer.Classes
{
    public class Tournament
    {
        public int id { get; set; } = 0;
        public int coordinatorId { get; set; }
        public string name { get; set; } = "";
        public int month { get; set; }
        public int year { get; set; }
        public int day { get; set; }
        public string time { get; set; }
        public T_Format format { get; set; }
        public int points { get; set; }
        public int point_flex { get; set; }
        public int hexes_max { get; set; }
        public int hexes_flex { get; set; }
        public List<TournyEntry> entries { get; set; } = new List<TournyEntry>();
        public int entrants_max { get; set; } = 0;
        public int join_code { get; set; } = 0;
    }
    public enum T_Format { Standard = 0, Heroes = 1, Doubles = 2 }
}
