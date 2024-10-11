using HeroscapeTournamentClient.Buttons;
using HeroscapeTournamentClient.Classes;
using HeroscapeTournamentClient.Components;
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
    public partial class Page_Battle : UserControl
    {
        FormMain MainForm;
        public Page_Battle(FormMain formMain)
        {
            InitializeComponent();
            MainForm = formMain;

            tourneyList1.battlePage = this;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            FormMain.ChangePage(Classes.Globals.PageLabel.PageMain);
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            CodeSubmit submit = new CodeSubmit(tournamentDetailPanel1.tourneyID);
            submit.myMaster = this;

            submit.Show();
        }
        public async void GoToArmyPickPage()
        {
            Page_BattlePickArmy temparmy = (Page_BattlePickArmy)FormMain.Pages[(int)Globals.PageLabel.PageBattleArmy];
            temparmy.tournament = tourneyList1.tournaments.Where(t => t.id == tournamentDetailPanel1.tourneyID).FirstOrDefault();
            temparmy.tourneyCollection = await ServerCommunication.GetTournamentAvailable(tournamentDetailPanel1.tourneyID);

            FormMain.ChangePage(Globals.PageLabel.PageBattleArmy);
        }

        private void Page_Battle_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                tournamentDetailPanel1.Visible = false;
                buttonEnter.Enabled = false;
                buttonEnter.Visible = false;

                tourneyList1.UpdateTournaments();
            }
        }
    }
}
