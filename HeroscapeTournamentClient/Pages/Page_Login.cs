using HeroscapeTournamentClient.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeroscapeTournamentClient.Pages
{
    public partial class Page_Login : UserControl
    {
        public int PageId = 0;
        public FormMain MainForm;
        public Page_Login(FormMain main)
        {
            InitializeComponent();
            labelError.Text = "";
            MainForm = main;
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Sent a login message to server");
            var response = await ServerCommunication.Login(textBoxEmail.Text, textBoxPassword.Text);

            if (response != null)
            {
                FormMain.myPlayer = response;
                FormMain.ChangePage(Globals.PageLabel.PageMain);

                Debug.WriteLine($"Got information for player {response.firstname} {response.lastname}");
            }
        }

        private void buttonSignup_Click(object sender, EventArgs e)
        {
            FormMain.ChangePage(Classes.Globals.PageLabel.PageSignup);
        }
    }
}
