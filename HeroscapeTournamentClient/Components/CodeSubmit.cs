using HeroscapeTournamentClient.Classes;
using HeroscapeTournamentClient.Pages;
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

namespace HeroscapeTournamentClient.Components
{
    public partial class CodeSubmit : Form
    {
        public int TournamentID;
        public Page_Battle myMaster;
        public CodeSubmit(int tourneyID)
        {
            InitializeComponent();
            TournamentID = tourneyID;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private async void buttonSubmit_Click(object sender, EventArgs e)
        {
            string codeString = textBoxCode.Text;

            if (codeString.All(char.IsDigit) && codeString.Length == 5)
            {
                bool result = await ServerCommunication.TournamentSubmitCode(TournamentID, int.Parse(textBoxCode.Text));

                Debug.WriteLine($"Was the code correct? {result}");

                if (result)
                {
                    myMaster.GoToArmyPickPage();

                    Dispose();
                }
                else
                {
                    labelError.Text = "Code is incorrect";
                }
            }
            else
            {
                labelError.Text = "Code must be 5 numbers";
            }
        }
    }
}
