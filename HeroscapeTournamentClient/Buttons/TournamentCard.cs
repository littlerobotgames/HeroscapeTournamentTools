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
    public partial class TournamentCard : UserControl
    {
        public TourneyList myMaster;
        public int tourneyId;
        public TournamentCard(TourneyList master, int tId)
        {
            InitializeComponent();

            myMaster = master;
            tourneyId = tId;
        }

        private void CardClicked(object sender, EventArgs e)
        {
            myMaster.UpdateTournamentViewer(tourneyId);
        }
    }
}
