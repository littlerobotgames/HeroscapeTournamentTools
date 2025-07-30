using HeroscapeTournamentClient.Classes;
using HeroscapeTournamentClient.Pages;
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
        public CurrentCardPanel showPanel;
        public CurrentCardPanelSmall showPanelSmall { get; set; }
        public int currentCardId = -1;
        public List<Card> AllCards { get; set; }
        public Page_Build MasterPage { get; set; }
        public FigureCollection AvailableUnits { get; set; } = new FigureCollection();
        public bool isBrowse { get; set; }
        public CardIconPanel()
        {
            InitializeComponent();
        }

        private void IconPanelLoad(object sender, EventArgs e)
        {
            UpdateList();
        }
        public void UpdateList()
        {
            while(Controls.Count > 0)
            {
                Controls.RemoveAt(0);
            }

            int start_X = 25;
            int start_Y = 25;

            List<string> filters_rarity = new List<string>();
            List<string> filters_type = new List<string>();

            switch (Page_Build.Format)
            {
                case T_Format.Standard:
                    break;
                case T_Format.Doubles:
                    break;
                case T_Format.Heroes:
                    break;
                case T_Format.GoV:
                    filters_rarity.Add("Unique");
                    filters_rarity.Add("Uncommon");
                    filters_type.Add("Hero");
                    break;
            }

            if (FormMain.AllCards.Count > 0)
            {
                foreach (Card card in FormMain.AllCards)
                {
                    if (CardRarityInFilters(card, filters_rarity) && CardTypeInFilters(card, filters_type))
                    {
                        CardIcon cardIcon = new CardIcon();

                        cardIcon.cardId = card.id;
                        cardIcon.labelCardName.Text = card.name;
                        cardIcon.labelPoints.Text = card.points.ToString();
                        cardIcon.Location = new Point(start_X, start_Y);
                        cardIcon.myMaster = this;

                        cardIcon.labelAmount.ForeColor = Globals.GetGeneralColorAccent(card.general);

                        if (isBrowse)
                        {
                            cardIcon.labelAmount.Text = "";

                            cardIcon.buttonSubtract.Enabled = false;
                            cardIcon.buttonSubtract.Visible = false;
                            cardIcon.buttonAdd.Enabled = false;
                            cardIcon.buttonAdd.Visible = false;
                        }
                        else
                        {
                            int totalFigures = 0;
                            int thisArmyFigures = 0;

                            int totalAmountIndex = AvailableUnits.armyEntries.FindIndex(e => e.cardId == cardIcon.cardId);
                            int thisArmyAmountIndex = Page_Build.currentArmy.ArmyEntries.FindIndex(e => e.cardId == cardIcon.cardId);

                            if (totalAmountIndex != -1)
                            {
                                totalFigures = AvailableUnits.armyEntries[totalAmountIndex].amount;
                            }

                            if (thisArmyAmountIndex != -1)
                            {
                                thisArmyFigures = Page_Build.currentArmy.ArmyEntries[thisArmyAmountIndex].amount;
                            }

                            cardIcon.AmountCurrent = thisArmyFigures;
                            cardIcon.AmountMax = totalFigures;

                            if (card.rarity == "Unique")
                            {
                                if (thisArmyFigures == 1)
                                {
                                    cardIcon.buttonAdd.Enabled = false;
                                    cardIcon.buttonAdd.Visible = false;
                                }
                            }
                            if (thisArmyFigures == 0)
                            {
                                cardIcon.buttonSubtract.Enabled = false;
                                cardIcon.buttonSubtract.Visible = false;
                            }
                        }

                        cardIcon.BackColor = Globals.GetGeneralColorBase(card.general);
                        cardIcon.labelCardName.ForeColor = Globals.GetGeneralColorAccent(card.general);
                        cardIcon.labelPoints.ForeColor = Globals.GetGeneralColorAccent(card.general);

                        Controls.Add(cardIcon);

                        start_X += 100;

                        if (start_X == 425)
                        {
                            start_X = 25;
                            start_Y += 80;
                        }
                    }
                }
            } 
        }
        public void SelectCard(int cardId)
        {
            if (cardId != currentCardId)
            {
                currentCardId = cardId;

                if (isBrowse)
                {
                    //Create abilities
                    while (showPanel.panelAbilities.Controls.Count > 0)
                    {
                        showPanel.panelAbilities.Controls.RemoveAt(0);
                    }

                    //Set label data of card
                    Card pickedCard = FormMain.AllCards.Where(c => c.id == cardId).FirstOrDefault();

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

                    Color backCol = Globals.GetGeneralColorBase(pickedCard.general);
                    Color accentCol = Globals.GetGeneralColorAccent(pickedCard.general);

                    showPanel.BackColor = backCol;

                    foreach (Control label in showPanel.Controls)
                    {
                        if (label is Label)
                        {
                            Label theLabel = (Label)label;
                            theLabel.ForeColor = accentCol;
                        }
                    }
                    showPanel.Visible = true;

                    int last_height = 25;
                    foreach (Ability ability in pickedCard.abilities)
                    {
                        AbilityDisplay abDisplay = new AbilityDisplay();

                        abDisplay.labelName.Text = ability.name;
                        abDisplay.labelName.ForeColor = accentCol;
                        abDisplay.labelDescription.Text = ability.description;
                        abDisplay.labelDescription.ForeColor = accentCol;
                        abDisplay.Location = new Point(25, last_height);
                        abDisplay.Height = abDisplay.labelDescription.Height + 50;
                        last_height += abDisplay.Height;

                        showPanel.panelAbilities.Controls.Add(abDisplay);
                    }
                }
                else
                {
                    //Create abilities
                    while (showPanelSmall.panelAbilities.Controls.Count > 0)
                    {
                        showPanelSmall.panelAbilities.Controls.RemoveAt(0);
                    }

                    //Set label data of card
                    Card pickedCard = FormMain.AllCards.Where(c => c.id == cardId).FirstOrDefault();

                    showPanelSmall.labelName.Text = pickedCard.name;
                    showPanelSmall.labelGeneral.Text = pickedCard.general;
                    showPanelSmall.labelSpecies.Text = pickedCard.race;
                    showPanelSmall.labelType.Text = $"{pickedCard.rarity} {pickedCard.type}";
                    showPanelSmall.labelClass.Text = pickedCard.unit_class;
                    showPanelSmall.labelPersonality.Text = pickedCard.personality;
                    showPanelSmall.labelHeight.Text = $"{pickedCard.size} {pickedCard.height}";
                    showPanelSmall.labelLifeNumber.Text = pickedCard.life.ToString();
                    showPanelSmall.labelMoveNumber.Text = pickedCard.move.ToString();
                    showPanelSmall.labelRangeNumber.Text = pickedCard.range.ToString();
                    showPanelSmall.labelAttackNumber.Text = pickedCard.attack.ToString();
                    showPanelSmall.labelDefenseNumber.Text = pickedCard.defense.ToString();
                    showPanelSmall.labelPoints.Text = $"{pickedCard.points} Points";
                    showPanelSmall.labelFigures.Text = $"{pickedCard.figures} Figures";
                    showPanelSmall.labelHexes.Text = $"{pickedCard.figures * pickedCard.hex_per} Hexes";
                    showPanelSmall.labelSet.Text = pickedCard.wave;
                    showPanelSmall.labelPack.Text = pickedCard.pack;

                    Color backCol = Globals.GetGeneralColorBase(pickedCard.general);
                    Color accentCol = Globals.GetGeneralColorAccent(pickedCard.general);

                    showPanelSmall.BackColor = backCol;

                    foreach (Control label in showPanelSmall.Controls)
                    {
                        if (label is Label)
                        {
                            Label theLabel = (Label)label;
                            theLabel.ForeColor = accentCol;
                        }
                    }
                    showPanelSmall.Visible = true;

                    int last_height = 25;
                    foreach (Ability ability in pickedCard.abilities)
                    {
                        AbilityDisplay abDisplay = new AbilityDisplay();

                        abDisplay.labelName.Text = ability.name;
                        abDisplay.labelName.ForeColor = accentCol;
                        abDisplay.labelName.Font = new Font("HelveticaNeue MediumCond", 6, FontStyle.Bold);
                        abDisplay.labelDescription.Text = ability.description;
                        abDisplay.labelDescription.ForeColor = accentCol;
                        abDisplay.labelDescription.Font = new Font("HelveticaNeue MediumCond", 6, FontStyle.Regular);
                        abDisplay.Location = new Point(25, last_height);
                        abDisplay.Height = abDisplay.labelDescription.Height + 50;
                        last_height += abDisplay.Height;

                        showPanelSmall.panelAbilities.Controls.Add(abDisplay);
                    }
                }
            }
        }
        private bool CardRarityInFilters(Card card, List<string> filters)
        {
            if (filters.Count == 0)
            {
                return true;
            }
            for(int i = 0; i < filters.Count; i++)
            {
                if (card.rarity == filters[i])
                {
                    return true;
                }
            }
            return false;
        }
        private bool CardTypeInFilters(Card card, List<string> filters)
        {
            if (filters.Count == 0)
            {
                return true;
            }
            for (int i = 0; i < filters.Count; i++)
            {
                if (card.type == filters[i])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
