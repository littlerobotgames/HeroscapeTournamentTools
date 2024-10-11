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
    public partial class Page_Browse : UserControl
    {
        public FormMain MainForm;
        public Page_Browse(FormMain form)
        {
            InitializeComponent();

            MainForm = form;

            cardIconPanel1.showPanel = currentCardPanel1;
            currentCardPanel1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMain.ChangePage(Classes.Globals.PageLabel.PageMain);
        }
    }
}
