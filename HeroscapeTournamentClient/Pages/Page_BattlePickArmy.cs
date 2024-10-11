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
    public partial class Page_BattlePickArmy : UserControl
    {
        public FigureCollection tourneyCollection = new FigureCollection();
        private int chosenArmyId = -1;
        public int ChosenArmyId 
        {
            get { return chosenArmyId; }
            set
            {
                chosenArmyId = value;

                if (chosenArmyId != -1) 
                {
                    buttonEnter.Enabled = true;
                }
            }
        }
        public Tournament tournament;

        public List<Army> armyList;
        public List<Army> presetList;
        public Page_BattlePickArmy(FormMain formMain)
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            FormMain.ChangePage(Classes.Globals.PageLabel.PageBattle);
        }

        private async void buttonEnter_Click(object sender, EventArgs e)
        {
            bool result = await ServerCommunication.SubmitArmy(tournament.id, FormMain.myPlayer.id, ChosenArmyId);

            if (result)
            {
                FormMain.ChangePage(Globals.PageLabel.PageBattle);
            }
        }

        private async void Page_BattlePickArmy_VisibleChanged(object sender, EventArgs e)
        {
            buttonEnter.Enabled = false;
            if (FormMain.myPlayer != null)
            {
                armyList = await ServerCommunication.GetPlayerArmies(FormMain.myPlayer.id);
                presetList = await ServerCommunication.GetPlayerArmies(tournament.coordinatorId);

                ReloadPlayerArmies();
                ReloadPresetArmies();
            }
        }

        private void ReloadPlayerArmies()
        {
            panelYourArmies.Controls.Clear();

            int start_y = 25;
            foreach (Army army in armyList)
            {
                ArmyCard tempCard = new ArmyCard(panelYourArmies);
                List<ArmyEntryCard> cardIcons = new List<ArmyEntryCard>();
                tempCard.CardId = army.id;

                int totalPoints = 0;
                int totalHexes = 0;
                int start_x = 8;

                foreach (ArmyEntry armyEntry in army.ArmyEntries)
                {
                    int amount = armyEntry.amount;
                    Card entryCard = FormMain.AllCards.Where(c => c.id == armyEntry.cardId).FirstOrDefault();

                    totalPoints += entryCard.points * amount;
                    totalHexes += (entryCard.hex_per * entryCard.figures) * amount;

                    ArmyEntryCard tempIcon = new ArmyEntryCard();
                    tempIcon.labelCardName.Text = entryCard.name;
                    tempIcon.labelAmount.Text = amount.ToString();
                    tempIcon.BackColor = Globals.GetGeneralColorBase(entryCard.general);
                    tempIcon.labelCardName.ForeColor = Globals.GetGeneralColorAccent(entryCard.general);
                    tempIcon.labelAmount.ForeColor = Globals.GetGeneralColorAccent(entryCard.general);
                    tempIcon.Location = new Point(start_x, 8);

                    tempCard.panelEntryCards.Controls.Add(tempIcon);

                    start_x += 128;
                }

                tempCard.labelName.Text = army.name;
                tempCard.labelHexesPoints.Text = $"{totalHexes} Hexes | {totalPoints} Points";
                tempCard.Location = new Point(25, start_y);

                tempCard.buttonEdit.Visible = false;
                tempCard.buttonDelete.Visible = false;

                panelYourArmies.Controls.Add(tempCard);

                start_y += 225;
            }
        }
        private void ReloadPresetArmies()
        {
            panelTournyPresets.Controls.Clear();

            int start_y = 25;
            foreach (Army army in presetList)
            {
                ArmyCard tempCard = new ArmyCard(panelTournyPresets);
                List<ArmyEntryCard> cardIcons = new List<ArmyEntryCard>();
                tempCard.CardId = army.id;

                int totalPoints = 0;
                int totalHexes = 0;
                int start_x = 8;

                foreach (ArmyEntry armyEntry in army.ArmyEntries)
                {
                    int amount = armyEntry.amount;
                    Card entryCard = FormMain.AllCards.Where(c => c.id == armyEntry.cardId).FirstOrDefault();

                    totalPoints += entryCard.points * amount;
                    totalHexes += (entryCard.hex_per * entryCard.figures) * amount;

                    ArmyEntryCard tempIcon = new ArmyEntryCard();
                    tempIcon.labelCardName.Text = entryCard.name;
                    tempIcon.labelAmount.Text = amount.ToString();
                    tempIcon.BackColor = Globals.GetGeneralColorBase(entryCard.general);
                    tempIcon.labelCardName.ForeColor = Globals.GetGeneralColorAccent(entryCard.general);
                    tempIcon.labelAmount.ForeColor = Globals.GetGeneralColorAccent(entryCard.general);
                    tempIcon.Location = new Point(start_x, 8);

                    tempCard.panelEntryCards.Controls.Add(tempIcon);

                    start_x += 128;
                }

                tempCard.labelName.Text = army.name;
                tempCard.labelHexesPoints.Text = $"{totalHexes} Hexes | {totalPoints} Points";
                tempCard.Location = new Point(25, start_y);

                tempCard.buttonEdit.Visible = false;
                tempCard.buttonDelete.Visible = false;

                panelTournyPresets.Controls.Add(tempCard);

                start_y += 225;
            }
        }
    }
}
