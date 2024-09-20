namespace HeroscapeTournamentServer.Classes
{
    public class Card
    {
        public int id { get; set; }
        public string name { get; set; }
        public string general { get; set; }
        public string rarity { get; set; }
        public string type { get; set; }
        public string race { get; set; }
        public string unit_class { get; set; }
        public string personality { get; set; }
        public string size { get; set; }
        public int height { get; set; }
        public int life { get; set; }
        public int move { get; set; }
        public int range { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public int points { get; set; }
        public int figures { get; set; }
        public int hex_per { get; set; }
        public List<Ability> abilities { get; set; }
        public string wave { get; set; }
        public string pack { get; set; }

        public void PrintCard()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Life: {life}");
            Console.WriteLine($"Move: {move}");
            Console.WriteLine($"Range: {range}");
            Console.WriteLine($"Attack: {attack}");
            Console.WriteLine($"Defense: {defense}");
            Console.WriteLine($"Points: {points}");

            for (int i = 0; i < abilities.Count; i++)
            {
                Console.WriteLine($"    {abilities[i].name}");
                Console.WriteLine($"        {abilities[i].description}");
            }
        }
        public void PrintAbilities()
        {
            Console.WriteLine($"\n{name} abilities");

            for (int i = 0; i < abilities.Count; i++)
            {
                Console.WriteLine($"    ({i}) {abilities[i].name}");
            }
        }
    }
}
