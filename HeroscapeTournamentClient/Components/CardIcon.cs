using HeroscapeTournamentClient.Classes;
using HeroscapeTournamentClient.Pages;
using HeroscapeTournamentServer.Classes;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeroscapeTournamentClient.Buttons
{
    public partial class CardIcon : UserControl
    {
        public int cardId;
        public CardIconPanel myMaster;

        private int _amountCurrent = 0;
        private int _amountMax = 0;

        public int AmountCurrent
        {
            get
            {
                return _amountCurrent;
            }
            set
            {
                _amountCurrent = value;
                UpdateAmount();
            }
        }
        public int AmountMax
        {
            get
            {
                return _amountMax;
            }
            set
            {
                _amountMax = value;
                UpdateAmount();
            }
        }
        public CardIcon()
        {
            InitializeComponent();
        }

        private void CardClicked(object sender, EventArgs e)
        {
            myMaster.SelectCard(cardId);
        }
        private void UpdateAmount()
        {
            labelAmount.Text = $"{_amountCurrent}/{_amountMax}";

            if (_amountMax == 0 || _amountCurrent > _amountMax)
            {
                labelAmount.ForeColor = Color.Red;
            }
            else
            {
                labelAmount.ForeColor = Globals.GetGeneralColorAccent(FormMain.AllCards.Where(c => c.id == cardId).FirstOrDefault().general);
            }

            Card card = FormMain.AllCards.Where(c => c.id == cardId).FirstOrDefault();

            if (card.rarity == "Unique")
            {
                if (_amountCurrent == 0)
                {
                    buttonAdd.Enabled = true;
                    buttonAdd.Visible = true;
                }
                else
                {
                    buttonAdd.Enabled = false;
                    buttonAdd.Visible = false;
                }
            }
            if (_amountCurrent == 0)
            {
                buttonSubtract.Enabled = false;
                buttonSubtract.Visible = false;
            }
            if (_amountCurrent > 0)
            {
                buttonSubtract.Enabled = true;
                buttonSubtract.Visible = true;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int EntryIndex = Page_Build.currentArmy.ArmyEntries.FindIndex(e => e.cardId == cardId);

            if (EntryIndex != -1)
            {
                Page_Build.currentArmy.ArmyEntries[EntryIndex].amount++;
            }
            else
            {
                ArmyEntry armyEntry = new ArmyEntry();
                armyEntry.amount = 1;
                armyEntry.cardId = cardId;

                Page_Build.currentArmy.ArmyEntries.Add(armyEntry);
            }

            AmountCurrent = _amountCurrent + 1;
            myMaster.MasterPage.UpdateArmyInfo();
            myMaster.MasterPage.UpdateRuleset();
            myMaster.MasterPage.Unsaved = true;
        }

        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            int EntryIndex = Page_Build.currentArmy.ArmyEntries.FindIndex(e => e.cardId == cardId);

            if (EntryIndex != -1)
            {
                Page_Build.currentArmy.ArmyEntries[EntryIndex].amount -= 1;

                if (Page_Build.currentArmy.ArmyEntries[EntryIndex].amount == 0)
                {
                    Page_Build.currentArmy.ArmyEntries.RemoveAt(EntryIndex);
                }

                AmountCurrent = _amountCurrent - 1;
                myMaster.MasterPage.UpdateArmyInfo();
                myMaster.MasterPage.UpdateRuleset();
                myMaster.MasterPage.Unsaved = true;
            }
        }
    }
}
