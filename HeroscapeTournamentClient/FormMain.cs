using HeroscapeTournamentClient.Classes;
using HeroscapeTournamentClient.Pages;
using HeroscapeTournamentServer.Classes;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace HeroscapeTournamentClient
{
    public partial class FormMain : Form
    {
        public List<UserControl> Pages;
        public PlayerPublic myPlayer;
        
        public FormMain()
        {
            InitializeComponent();

            Pages = new List<UserControl> { 
                new Page_Login(this),
                new Page_Signup(this),
                new Page_Main(this),
                new Page_Browse(this),
                new Page_Build(this),
                new Page_Battle(this)
            };

            foreach (UserControl page in Pages)
            {
                page.Hide();
                Controls.Add(page);
            }

            ServerCommunication.RunAsync().GetAwaiter().GetResult();
        }

        private async void FormMainLoaded(object sender, EventArgs e)
        {
            labelError.Text = "";
            labelError.SendToBack();

            Debug.WriteLine("Sent Ping request");
            var response = await ServerCommunication.PingServer();
            Debug.WriteLine($"Ping answer is {response.StatusCode}");

            if (response.IsSuccessStatusCode)
            {
                Pages[(int)Globals.PageLabel.PageLogin].Show();
            }
            else
            {
                labelError.Text = "Could not connect to server";
            }
        }
        public void ChangePage(Globals.PageLabel _page)
        {
            foreach(UserControl page in Pages)
            {
                page.Hide();
            }
            Pages[(int)_page].Show();
        }
    }
}