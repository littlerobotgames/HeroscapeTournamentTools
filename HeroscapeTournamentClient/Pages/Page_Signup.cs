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
    public partial class Page_Signup : UserControl
    {
        public FormMain MainForm;
        public Page_Signup(FormMain main)
        {
            InitializeComponent();
            MainForm = main;
        }
    }
}
