using Microsoft.VisualBasic.ApplicationServices;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows.Forms.VisualStyles;

namespace HeroscapeDataInputter
{
    
    public partial class FormMain : Form
    {
        public class Set
        {
            public string name { get; set; }
            public string date { get; set; }
            public string type { get; set; }
            public string alternate { get; set; }
            public string[] packs { get; set; }
        }
        public class Card
        {
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
        public class Ability
        {
            public string name { get; set; }
            public string description { get; set; }
        }
        public List<Set> sets;
        public List<Card> cards;
        public string[] Generals = { "Jandar", "Ullar", "Einar", "Vydar", "Utgar", "Aquilla", "Valkrill", "Marvel"};
        public string[] Sizes = { "Small", "Medium", "Large", "Huge" };
        public string[] Rarity = { "Common", "Uncommon", "Unique" };
        public string[] Type = { "Squad", "Hero" };
        public Card CurrentCard;

        public string Root = System.IO.Path.GetFullPath(@"..\..\..\");
        public FormMain()
        {
            InitializeComponent();

            string text = File.ReadAllText(Root + "/gamedata/data_waves.json");
            sets = JsonSerializer.Deserialize<List<Set>>(text);

            text = File.ReadAllText(Root + "/gamedata/data_figures.json");
            cards = JsonSerializer.Deserialize<List<Card>>(text);

            UpdateListBox();

            comboBox_generals.DataSource = Generals;
            comboBox_rarity.DataSource = Rarity;
            comboBox_type.DataSource = Type;
            comboBox_size.DataSource = Sizes;
            comboBox_wave.DataSource = sets.Select(c => c.name).ToArray();

            CreateNewCard();
        }
        public void CreateNewCard()
        {
            Card NewCard = new Card();

            NewCard.name = "New Card";
            NewCard.general = "Jandar";
            NewCard.rarity = "Unique";
            NewCard.type = "Hero";
            NewCard.race = "Human";
            NewCard.unit_class = "Warrior";
            NewCard.personality = "Valiant";
            NewCard.size = "Medium";
            NewCard.height = 5;
            NewCard.life = 5;
            NewCard.move = 5;
            NewCard.range = 1;
            NewCard.attack = 3;
            NewCard.defense = 3;
            NewCard.points = 75;
            NewCard.figures = 1;
            NewCard.hex_per = 1;
            NewCard.abilities = new List<Ability>();
            NewCard.wave = "Rise of the Valkyrie";
            NewCard.pack = "";

            LoadCard(NewCard);
        }
        public void SaveFigures()
        {
            string text = JsonSerializer.Serialize(cards);
            File.WriteAllText(Root + "/gamedata/data_figures.json", text);
        }

        private void button_save_click(object sender, EventArgs e)
        {
            SaveFigures();
        }

        private void button_newcard_click(object sender, EventArgs e)
        {
            CreateNewCard();

            UpdateListBox();
        }
        private void UpdateListBox()
        {
            listbox_cards.Items.Clear();

            foreach (Card card in cards)
            {
                listbox_cards.Items.Add(card.name);
            }
        }
        private void button_click_load(object sender, EventArgs e)
        {
            LoadCard(GetCard(listbox_cards.Text));
        }
        private Card GetCard(string n)
        {
            foreach(Card card in cards) 
            { 
            if (card.name == n) return card;
            }

            return null;
        }
        public void LoadCard(Card card)
        {
            CurrentCard = card;

            Console.WriteLine("-> Load Card Function ->");

            CurrentCard.PrintAbilities();

            if (CurrentCard != null)
            {
                textBox_name.Text = CurrentCard.name;
                comboBox_generals.SelectedItem = CurrentCard.general;
                comboBox_rarity.SelectedItem = CurrentCard.rarity;
                comboBox_type.SelectedItem = CurrentCard.type;
                textBox_race.Text = CurrentCard.race;
                textBox_class.Text = CurrentCard.unit_class;
                textBox_personality.Text = CurrentCard.personality;
                comboBox_size.SelectedItem = CurrentCard.size;
                numericUpDown_height.Value = CurrentCard.height;
                numericUpDown_life.Value = CurrentCard.life;
                numericUpDown_move.Value = CurrentCard.move;
                numericUpDown_range.Value = CurrentCard.range;
                numericUpDown_attack.Value = CurrentCard.attack;
                numericUpDown_defense.Value = CurrentCard.defense;
                numericUpDown_points.Value = CurrentCard.points;
                numericUpDown_figures.Value = CurrentCard.figures;
                numericUpDown_hexes.Value = CurrentCard.hex_per;
                comboBox_wave.SelectedItem = CurrentCard.wave;
                comboBox_pack.SelectedItem = CurrentCard.pack;

                MakeAbilityCards();

                CurrentCard.PrintAbilities();
            }
        }
        private void SaveCard()
        {
            bool cardExists = false;
            for (int i = 0; i < cards.Count; i++)
            {
                if (!cardExists)
                {
                    if (cards[i].name == CurrentCard.name)
                    {
                        cardExists = true;
                    }
                }
                
            }

            CurrentCard.name = textBox_name.Text;
            CurrentCard.general = comboBox_generals.Text;
            CurrentCard.rarity = comboBox_rarity.Text;
            CurrentCard.type = comboBox_type.Text;
            CurrentCard.race = textBox_race.Text;
            CurrentCard.unit_class = textBox_class.Text;
            CurrentCard.personality = textBox_personality.Text;
            CurrentCard.size = comboBox_size.Text;
            CurrentCard.height = Convert.ToInt32(numericUpDown_height.Value);
            CurrentCard.figures = Convert.ToInt32(numericUpDown_figures.Value);
            CurrentCard.hex_per = Convert.ToInt32(numericUpDown_hexes.Value);
            CurrentCard.life = Convert.ToInt32(numericUpDown_life.Value);
            CurrentCard.move = Convert.ToInt32(numericUpDown_move.Value);
            CurrentCard.range = Convert.ToInt32(numericUpDown_range.Value);
            CurrentCard.attack = Convert.ToInt32(numericUpDown_attack.Value);
            CurrentCard.defense = Convert.ToInt32(numericUpDown_defense.Value);
            CurrentCard.points = Convert.ToInt32(numericUpDown_points.Value);
            CurrentCard.wave = comboBox_wave.Text;
            CurrentCard.pack = comboBox_pack.Text;

            if (!cardExists)
            {
                cards.Add(CurrentCard);
            }
         
            UpdateListBox();
        }
        public void MakeAbilityCards()
        {
            Console.WriteLine("[] Make Ability Cards []");

            panel_ability_cards.Controls.Clear();

            for (int a = 0; a < CurrentCard.abilities.Count; a++)
            {
                AbilityCard tempAb = new AbilityCard(this);

                tempAb.index = a;
                tempAb.name = CurrentCard.abilities[a].name;
                tempAb.description = CurrentCard.abilities[a].description;
                tempAb.Show();

                tempAb.Location = new Point(
                    tempAb.Location.X,
                    tempAb.Location.Y + (a * 150));

                panel_ability_cards.Controls.Add(tempAb);
            }
        }
        private void button_savecard_click(object sender, EventArgs e)
        {
            SaveCard();
        }
        private void button_ab_add(object sender, EventArgs e)
        {
            Console.WriteLine("~~~ Add ability button pushed ~~~");
            CurrentCard.PrintAbilities();

            Console.WriteLine($"++ Adding new ability");
            Ability temp = new Ability();
            temp.name = "New Name";
            temp.description = "New Description";
            CurrentCard.abilities.Add(temp);

            CurrentCard.PrintAbilities();

            MakeAbilityCards();
        }

        private void comboBox_wave_changed(object sender, EventArgs e)
        {
            foreach(Set set in sets)
            {
                if (set.name == comboBox_wave.Text)
                {
                    comboBox_pack.DataSource = set.packs;
                }
            }
        }
    }
}