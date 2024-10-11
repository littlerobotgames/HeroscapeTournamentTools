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
    public partial class ButtonMenu : UserControl
    {
        public Page_Main mainpage;
        public Globals.PageLabel toPage;

        public ButtonMenu(Page_Main _mainPage)
        {
            InitializeComponent();

            mainpage = _mainPage;
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            FormMain.ChangePage(toPage);
        }
    }
}
