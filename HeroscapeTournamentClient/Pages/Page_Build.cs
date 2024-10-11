using HeroscapeTournamentClient.Buttons;
using HeroscapeTournamentClient.Classes;
using HeroscapeTournamentServer.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeroscapeTournamentClient.Pages
{
    public partial class Page_Build : UserControl
    {
        public FormMain MainForm;
        public static Army currentArmy = new Army();
        public static List<Tournament> tournamentList;
        private static bool unsaved = false;
        public bool Unsaved 
        { 
            get { return unsaved; }
            set 
            { 
                unsaved = value;

                if (unsaved)
                {
                    buttonSave.Text = "Save Army*";
                }
                else
                {
                    buttonSave.Text = "Save Army";
                }
                
            }
        }

        public static int PointLimit { get; set; }
        public static int PointSoft { get; set; }
        public static int HexLimit { get; set; }
        public static int HexSoft { get; set; }
        public Page_Build(FormMain mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            FormMain.ChangePage(Classes.Globals.PageLabel.PageBuildMenu);
        }
        public void UpdateArmyInfo()
        {
            textBoxName.Text = currentArmy.name;
            Unsaved = false;

            UpdateArmyCards();
        }

        private async void LoadPageBuild(object sender, EventArgs e)
        {
            cardIconPanel1.MasterPage = this;
        }

        private async void TournamentPicked(object sender, EventArgs e)
        {
            Tournament tournament = tournamentList.Where(t => t.name == comboBoxTournament.Text).FirstOrDefault();

            if (tournament != null)
            {
                PointLimit = tournament.points;
                PointSoft = tournament.point_flex;
                HexLimit = tournament.hexes_max;
                HexSoft = tournament.hexes_flex;
            }

            UpdateRuleset();

            cardIconPanel1.AvailableUnits = await ServerCommunication.GetTournamentAvailable(tournament.id);
            cardIconPanel1.UpdateList();
        }
        public void UpdateRuleset()
        {
            int totalPoints = 0;
            int totalHexes = 0;

            foreach(ArmyEntry armyEntry in currentArmy.ArmyEntries)
            {
                Card cardData = FormMain.AllCards.Where(c => c.id == armyEntry.cardId).FirstOrDefault();

                totalPoints += cardData.points * armyEntry.amount;
                totalHexes += cardData.hex_per * cardData.figures * armyEntry.amount;
            }

            labelPoints.Text = $"Points: {totalPoints}/{PointLimit}";
            
            if (HexSoft > 0)
            {
                labelPoints.Text += $" (+{PointSoft})";
            }

            labelHexes.Text = $"Hexes: {totalHexes}/{HexLimit}";

            if (HexSoft > 0)
            {
                labelHexes.Text += $" (+{HexSoft})";
            }

            if (totalPoints > (PointLimit + PointSoft))
            {
                labelPoints.ForeColor = Color.Red;
            }
            else 
            {
                labelPoints.ForeColor = Color.Black;
            }
            if (totalHexes > (HexLimit + HexSoft))
            {
                labelHexes.ForeColor = Color.Red;
            }
            else
            {
                labelHexes.ForeColor = Color.Black;
            }
        }
        public void UpdateArmyCards()
        {
            panelCards.Controls.Clear();

            int start_x = 20;
            foreach(ArmyEntry entry in currentArmy.ArmyEntries)
            {
                Card card = FormMain.AllCards.Where(c => c.id == entry.cardId).FirstOrDefault();

                ArmyEntryCard armyEntryCard = new ArmyEntryCard();

                armyEntryCard.labelCardName.Text = card.name;
                armyEntryCard.labelAmount.Text = entry.amount.ToString();

                armyEntryCard.BackColor = Globals.GetGeneralColorBase(card.general);
                armyEntryCard.labelCardName.ForeColor = Globals.GetGeneralColorAccent(card.general);
                armyEntryCard.labelAmount.ForeColor = Globals.GetGeneralColorAccent(card.general);

                armyEntryCard.Location = new Point(start_x, 40);

                panelCards.Controls.Add(armyEntryCard);

                start_x += 128;
            }
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            int result = await ServerCommunication.SaveArmy(currentArmy);

            if (result != -1)
            {
                Unsaved = false;
                currentArmy.id = result;
            }
        }

        private void ArmyNameChanged(object sender, EventArgs e)
        {
            currentArmy.name = textBoxName.Text;
            Unsaved = true;
        }

        private async void PageBuildVisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                tournamentList = await ServerCommunication.GetTournaments();

                if (tournamentList != null)
                {
                    comboBoxTournament.Items.Clear();

                    foreach (Tournament tournament in tournamentList)
                    {
                        comboBoxTournament.Items.Add(tournament.name);
                    }
                }

                UpdateArmyInfo();
                UpdateRuleset();
                UpdateArmyCards();
            }
        }
    }
}
