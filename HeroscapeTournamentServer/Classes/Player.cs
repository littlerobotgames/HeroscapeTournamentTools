namespace HeroscapeTournamentServer.Classes
{
    public class Player
    {
        public int id { get; set; } = 0;
        public string firstname { get; set; } = "";
        public string lastname { get; set; } = "";
        public string email { get; set; }
        public string password { get; set; }
        public int medals_gold { get; set; } = 0;
        public int medals_silver { get; set; } = 0;
        public int medals_bronze { get; set; } = 0;
        public int[] armies { get; set; } = new int[0];
        public int accountType { get; set; } = 0;
    }
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

        public PlayerPublic(Player p)
        {
            id = p.id;
            firstname = p.firstname;
            lastname = p.lastname;
            medals_gold = p.medals_gold;
            medals_silver = p.medals_silver;
            medals_bronze = p.medals_bronze;
            armies = p.armies;
            accountType = p.accountType;
        }
    }
}
