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
    public partial class Page_Build : UserControl
    {
        FormMain MainForm;
        public Page_Build(FormMain mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
        }
    }
}
