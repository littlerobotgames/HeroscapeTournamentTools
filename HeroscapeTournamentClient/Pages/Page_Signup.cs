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
    public partial class Page_Signup : UserControl
    {
        public FormMain MainForm;
        public Page_Signup(FormMain main)
        {
            InitializeComponent();
            MainForm = main;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            FormMain.ChangePage(Classes.Globals.PageLabel.PageLogin);
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            int signupScore = 0;
            if (textBoxEmail.Text.Contains(".com") && textBoxEmail.Text.Contains("@"))
            {
                signupScore++;
            }
            
            if (textBoxPassword.Text.Trim() == textBoxPasswordConfirm.Text.Trim())
            {
                signupScore++;
            }
            if (textBoxPassword.Text.Trim().Length > 0)
            {
                signupScore++;
            }

            if (signupScore == 3)
            {
                bool response = await ServerCommunication.ProfileCreateNew(textBoxFirstName.Text, textBoxLastName.Text, textBoxEmail.Text, textBoxPassword.Text);

                if (response)
                {
                    FormMain.ChangePage(Globals.PageLabel.PageLogin);
                }
            }
        }
    }
}
