namespace HeroscapeTournamentServer.Classes
{
    public class PlayerPublic
    {
        public int id { get; set; } = 0;
        public string firstname { get; set; } = "";
        public string lastname { get; set; } = "";
        public int medals_gold { get; set; } = 0;
        public int medals_silver { get; set; } = 0;
        public int medals_bronze { get; set; } = 0;
        public int[] armies { get; set; } = new int[0];
        public int accountType { get; set; } = 0;
    }
}
