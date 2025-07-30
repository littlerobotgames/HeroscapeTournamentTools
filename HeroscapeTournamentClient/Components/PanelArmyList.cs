using HeroscapeTournamentClient.Classes;
using HeroscapeTournamentClient.Pages;
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

namespace HeroscapeTournamentClient.Buttons
{
    public partial class PanelArmyList : Panel
    {
        public List<Army> MyArmies = new List<Army>();
        
        public PanelArmyList()
        {
            InitializeComponent();
        }

        public async void GetPlayerArmies(int _playerId)
        {
            MyArmies = await ServerCommunication.GetPlayerArmies(_playerId);

            UpdateCards();
        }

        public void UpdateCards()
        {
            while(Controls.Count > 0)
            {
                Controls[0].Dispose();
            }

            int start_y = 12;
            foreach(Army army in MyArmies)
            {
                ArmyCard tempCard = new ArmyCard(this);
                List<ArmyEntryCard> cardIcons = new List<ArmyEntryCard>();
                tempCard.CardId = army.id;

                int totalPoints = 0;
                int totalHexes = 0;
                int start_x = 8;

                foreach(ArmyEntry armyEntry in army.ArmyEntries)
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

                    start_x += 80;
                }

                tempCard.labelName.Text = army.name;
                tempCard.labelHexesPoints.Text = $"{totalHexes} Hexes | {totalPoints} Points";
                tempCard.Location = new Point(25, start_y);

                Controls.Add(tempCard);

                start_y += 110;
            }
        }
    }
}
