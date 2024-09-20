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
    public partial class CardIcon : UserControl
    {
        public int cardId;
        public CardIconPanel myMaster;
        public CardIcon()
        {
            InitializeComponent();
        }

        private void CardClicked(object sender, EventArgs e)
        {
            myMaster.SelectCard(cardId);
        }
    }
}
