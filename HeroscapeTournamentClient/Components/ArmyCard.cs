using HeroscapeTournamentClient.Classes;
using HeroscapeTournamentClient.Pages;
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
    public partial class ArmyCard : UserControl
    {
        public int CardId { get; set; }
        public PanelArmyList ListPanel;
        public Panel GenericPanel;
        public ArmyCard(PanelArmyList listPanel)
        {
            InitializeComponent();
            ListPanel = listPanel;
        }
        public ArmyCard(Panel genPanel)
        {
            InitializeComponent();
            GenericPanel = genPanel;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Page_Build.currentArmy = ListPanel.MyArmies.Where(a => a.id == CardId).FirstOrDefault();
            FormMain.ChangePage(Globals.PageLabel.PageBuild);
            Page_Build thepage = (Page_Build)FormMain.Pages[(int)Globals.PageLabel.PageBuild];
            thepage.UpdateArmyInfo();
        }

        private void CardClicked(object sender, EventArgs e)
        {
            if (GenericPanel != null)
            {
                Page_BattlePickArmy thepage = (Page_BattlePickArmy)FormMain.Pages[(int)Globals.PageLabel.PageBattleArmy];

                thepage.ChosenArmyId = CardId;

                foreach(Control control in GenericPanel.Controls)
                {
                    control.BackColor = Color.Silver;
                }

                BackColor = Color.LightBlue;
            }
        }
    }
}
