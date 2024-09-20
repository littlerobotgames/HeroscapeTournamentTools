using HeroscapeTournamentClient.Buttons;
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

            tournamentDetailPanel1.Visible = false;
            buttonEnter.Enabled = false;
            buttonEnter.Visible = false;
            tourneyList1.battlePage = this;
        }
    }
}
