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
    public partial class Page_BuildMenu : UserControl
    {
        FormMain MainForm;
        public Page_BuildMenu(FormMain mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
        }

        private void PageBuildMenu_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            FormMain.ChangePage(Classes.Globals.PageLabel.PageMain);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Page_Build.currentArmy = new HeroscapeTournamentServer.Classes.Army();
            Page_Build.currentArmy.playerId = FormMain.myPlayer.id;

            FormMain.ChangePage(Classes.Globals.PageLabel.PageBuild);
        }

        private void BuildMenuVisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                panelArmyList1.GetPlayerArmies(FormMain.myPlayer.id);
            } 
        }
    }
}
