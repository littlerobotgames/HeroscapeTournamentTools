using HeroscapeTournamentClient.Classes;
using HeroscapeTournamentServer.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HeroscapeTournamentClient.Buttons
{
    public partial class CardIconPanel : UserControl
    {
        private List<Card> allcards = new List<Card>();
        public CurrentCardPanel showPanel;
        public int currentCardId = -1;
        public List<Card> AllCards { get; set; }

        public bool isBrowse { get; set; }
        public CardIconPanel()
        {
            InitializeComponent();
        }

        private async void IconPanelLoad(object sender, EventArgs e)
        {
            var response = await ServerCommunication.GetCardDatabase();

            if (response != null)
            {
                AllCards = response;
            }
            UpdateList();
        }
        private void UpdateList()
        {
            while(Controls.Count > 0)
            {
                Controls.RemoveAt(0);
            }

            int start_X = 50;
            int start_Y = 50;

            if (AllCards.Count > 0)
            {
                foreach (Card card in AllCards)
                {
                    CardIcon cardIcon = new CardIcon();

                    cardIcon.cardId = card.id;
                    cardIcon.labelCardName.Text = card.name;
                    cardIcon.labelPoints.Text = card.points.ToString();
                    cardIcon.Location = new Point(start_X, start_Y);
                    cardIcon.myMaster = this;

                    if (isBrowse)
                    {
                        cardIcon.labelAmount.Text = "";
                    }

                    switch (card.general)
                    {
                        case "Jandar":
                            cardIcon.BackColor = Color.LightBlue;
                            break;
                        case "Ullar":
                            cardIcon.BackColor = Color.LightGreen;
                            break;
                        case "Vydar":
                            cardIcon.BackColor = Color.LightGray;
                            break;
                        case "Einar":
                            cardIcon.BackColor = Color.Tan;
                            break;
                        case "Utgar":
                            cardIcon.BackColor = Color.PaleVioletRed;
                            break;
                        case "Aquilla":
                            cardIcon.BackColor = Color.DarkBlue;
                            cardIcon.labelCardName.ForeColor = Color.White;
                            cardIcon.labelPoints.ForeColor = Color.White;
                            break;
                        case "Valkrill":
                            cardIcon.BackColor = Color.Yellow;
                            break;
                        case "Marvel":
                            cardIcon.BackColor = Color.Purple;
                            cardIcon.labelCardName.ForeColor = Color.White;
                            cardIcon.labelPoints.ForeColor = Color.White;
                            break;
                    }

                    Controls.Add(cardIcon);

                    start_X += 200;

                    if (start_X == 850)
                    {
                        start_X = 50;
                        start_Y += 175;
                    }
                }
            } 
        }
        public void SelectCard(int cardId)
        {
            if (cardId != currentCardId)
            {
                currentCardId = cardId;
                //Create abilities
                while (showPanel.panelAbilities.Controls.Count > 0)
                {
                    showPanel.panelAbilities.Controls.RemoveAt(0);
                }

                //Set label data of card
                Card pickedCard = AllCards.Where(c => c.id == cardId).FirstOrDefault();

                showPanel.labelName.Text = pickedCard.name;
                showPanel.labelGeneral.Text = pickedCard.general;
                showPanel.labelSpecies.Text = pickedCard.race;
                showPanel.labelType.Text = $"{pickedCard.rarity} {pickedCard.type}";
                showPanel.labelClass.Text = pickedCard.unit_class;
                showPanel.labelPersonality.Text = pickedCard.personality;
                showPanel.labelHeight.Text = $"{pickedCard.size} {pickedCard.height}";
                showPanel.labelLifeNumber.Text = pickedCard.life.ToString();
                showPanel.labelMoveNumber.Text = pickedCard.move.ToString();
                showPanel.labelRangeNumber.Text = pickedCard.range.ToString();
                showPanel.labelAttackNumber.Text = pickedCard.attack.ToString();
                showPanel.labelDefenseNumber.Text = pickedCard.defense.ToString();
                showPanel.labelPoints.Text = $"{pickedCard.points} Points";
                showPanel.labelFigures.Text = $"{pickedCard.figures} Figures";
                showPanel.labelHexes.Text = $"{pickedCard.figures * pickedCard.hex_per} Hexes";
                showPanel.labelSet.Text = pickedCard.wave;
                showPanel.labelPack.Text = pickedCard.pack;

                //Set Colors
                Color backCol = Color.Gray;
                Color textCol = Color.Black;

                switch (pickedCard.general)
                {
                    case "Jandar":
                        backCol = Color.LightBlue;
                        textCol = Color.Black;
                        break;
                    case "Ullar":
                        backCol = Color.LightGreen;
                        textCol = Color.Black;
                        break;
                    case "Vydar":
                        backCol = Color.LightGray;
                        textCol = Color.Black;
                        break;
                    case "Einar":
                        backCol = Color.Tan;
                        textCol = Color.Black;
                        break;
                    case "Utgar":
                        backCol = Color.PaleVioletRed;
                        textCol = Color.Black;
                        break;
                    case "Aquilla":
                        backCol = Color.DarkBlue;
                        textCol = Color.White;
                        break;
                    case "Valkrill":
                        backCol = Color.Yellow;
                        textCol = Color.Black;
                        break;
                    case "Marvel":
                        backCol = Color.Purple;
                        textCol = Color.White;
                        break;
                }
                showPanel.BackColor = backCol;

                foreach (Control label in showPanel.Controls)
                {
                    if (label is Label)
                    {
                        Label theLabel = (Label)label;
                        theLabel.ForeColor = textCol;
                    }
                }
                showPanel.Visible = true;

                int last_height = 25;
                foreach (Ability ability in pickedCard.abilities)
                {
                    AbilityDisplay abDisplay = new AbilityDisplay();

                    abDisplay.labelName.Text = ability.name;
                    abDisplay.labelName.ForeColor = textCol;
                    abDisplay.labelDescription.Text = ability.description;
                    abDisplay.labelDescription.ForeColor = textCol;
                    abDisplay.Location = new Point(25, last_height);
                    abDisplay.Height = abDisplay.labelDescription.Height + 50;
                    last_height += abDisplay.Height;

                    showPanel.panelAbilities.Controls.Add(abDisplay);
                }
            }
            
        }
    }
}
