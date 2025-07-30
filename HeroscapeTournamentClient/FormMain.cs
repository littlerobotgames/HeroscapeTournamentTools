using HeroscapeTournamentClient.Classes;
using HeroscapeTournamentClient.Pages;
using HeroscapeTournamentServer.Classes;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace HeroscapeTournamentClient
{
    public partial class FormMain : Form
    {
        public static List<UserControl> Pages;
        public static PlayerPublic myPlayer;
        public static List<Card> AllCards = new List<Card>();
        public static string DatabaseVersion = "1.0.1";
        
        public FormMain()
        {
            InitializeComponent();

            Pages = new List<UserControl> { 
                new Page_Login(this),
                new Page_Signup(this),
                new Page_Main(this),
                new Page_Browse(this),
                new Page_Build(this),
                new Page_Battle(this),
                new Page_BuildMenu(this),
                new Page_BattlePickArmy(this)
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

            Debug.WriteLine("Get database version");
            var version = await ServerCommunication.GetDatabaseVersion();
            Debug.WriteLine($"Ping answer is {version}");

            if (version != DatabaseVersion)
            {
                AllCards = await ServerCommunication.GetCardDatabase();
            }
        }
        public static void ChangePage(Globals.PageLabel _page)
        {
            foreach(UserControl page in Pages)
            {
                page.Hide();
                page.Visible = false;
            }
            Pages[(int)_page].Show();
            Pages[(int)_page].Visible = true;
        }
        public static List<Card> GetCollectionData()
        {
            return AllCards;
        }
    }
}