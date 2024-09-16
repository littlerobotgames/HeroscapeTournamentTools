using HeroscapeTournamentServer.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Collections.Generic;
using System.Text.Json;
using Heroscape_Collection_Maker.UserControls;
using System.Diagnostics;

namespace Heroscape_Collection_Maker
{
    public partial class Form1 : Form
    {
        public FigureCollection mainCollection= new FigureCollection();
        public List<Set> sets;
        public List<Card> cards;
        public string Root = System.IO.Path.GetFullPath(@"..\..\..\");
        public Form1()
        {
            InitializeComponent();

            string text = File.ReadAllText(Root + "/gamedata/data_waves.json");
            sets = JsonSerializer.Deserialize<List<Set>>(text);

            text = File.ReadAllText(Root + "/gamedata/data_figures.json");
            cards = JsonSerializer.Deserialize<List<Card>>(text);

            //Make blank collection
            int startY = 0;

            foreach(Card card in cards)
            {
                ArmyEntry tempEntry = new ArmyEntry();
                tempEntry.cardId = card.id;
                tempEntry.amount = 0;
                mainCollection.armyEntries.Add(tempEntry);

                FigureEditor tempEditor = new FigureEditor(card.id, card.name, 0);
                tempEditor.Location = new Point(0, startY);
                panelCardlist.Controls.Add(tempEditor);

                startY += 50;
            }
        }

        private void buttonSaveClick(object sender, EventArgs e)
        {
            foreach(Control control in panelCardlist.Controls)
            {
                if (control is FigureEditor)
                {
                    FigureEditor editor = (FigureEditor)control;
                    Debug.WriteLine($"Found editor for {editor.cardName}");
                    mainCollection.armyEntries.Where(e => e.cardId == editor.cardId).FirstOrDefault().amount = editor.amount;
                }
            }

            string text = JsonSerializer.Serialize(mainCollection);
            File.WriteAllText(Root + "/gamedata/collections/" + textBoxCollectionName.Text + ".json", text);
        }
    }
}