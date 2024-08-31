using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeroscapeDataInputter
{
    public partial class AbilityCard : UserControl
    {
        private string _name;
        private string _description;
        private int _index;
        public string name { get { return _name; } set { _name = value; textBox_name.Text = value; } }
        public string description { get { return _description; } set { _description = value;  textBox_description.Text = value; } }
        public int index { get { return _index; } set { _index = value; labelNumber.Text = (value + 1).ToString(); } }
        public FormMain Master { get; set; }
        public AbilityCard(FormMain main)
        {
            Master = main;
            InitializeComponent();
        }
        private void button_x_clicked(object sender, EventArgs e)
        {
            Console.WriteLine("~~~ Remove ability button pushed ~~~");
            Master.CurrentCard.PrintAbilities();

            Console.WriteLine($"XX Deleting ability at index {index} ({Master.CurrentCard.abilities[index].name})");

            Master.CurrentCard.abilities.RemoveAt(index);

            Master.CurrentCard.PrintAbilities();

            Master.MakeAbilityCards();

            
        }
        private void textBox_ab_name_changed(object sender, EventArgs e)
        {
            Master.CurrentCard.abilities[index].name = textBox_name.Text;
        }
        private void textBox_ab_desc_changed(object sender, EventArgs e)
        {
            Master.CurrentCard.abilities[index].description = textBox_description.Text;
        }
    }
}
