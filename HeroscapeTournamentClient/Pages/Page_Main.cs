using HeroscapeTournamentClient.Classes;
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
    public partial class Page_Main : UserControl
    {
        public FormMain MainForm;
        public Page_Main(FormMain main)
        {
            InitializeComponent();

            MainForm = main;
        }

        private void PageMain_VisibleChanged(object sender, EventArgs e)
        {
            labelUsername.Text = $"{FormMain.myPlayer.firstname} {FormMain.myPlayer.lastname}";

            //Configure menu buttons

            //Battle
            buttonMenu_Join.labelName.Text = "Battle";
            buttonMenu_Join.labelName.ForeColor = Color.White;
            buttonMenu_Join.labelDescription.Text = "Find tournaments to enter and battle in";
            buttonMenu_Join.labelDescription.ForeColor = Color.White;
            buttonMenu_Join.BackColor = Color.Maroon;
            buttonMenu_Join.toPage = Globals.PageLabel.PageBattle;

            //Build
            buttonMenu_Build.labelName.Text = "Build";
            buttonMenu_Build.labelName.ForeColor = Color.White;
            buttonMenu_Build.labelDescription.Text = "Build an army, either for fun or a specific tournament";
            buttonMenu_Build.labelDescription.ForeColor = Color.White;
            buttonMenu_Build.BackColor = Color.DarkGreen;
            buttonMenu_Build.toPage = Globals.PageLabel.PageBuildMenu;

            //Browse
            buttonMenu_Browse.labelName.Text = "Browse";
            buttonMenu_Browse.labelName.ForeColor = Color.White;
            buttonMenu_Browse.labelDescription.Text = "Browse through every card in Heroscape";
            buttonMenu_Browse.labelDescription.ForeColor = Color.White;
            buttonMenu_Browse.BackColor = Color.DarkBlue;
            buttonMenu_Browse.toPage = Globals.PageLabel.PageBrowse;
        }
    }
}
