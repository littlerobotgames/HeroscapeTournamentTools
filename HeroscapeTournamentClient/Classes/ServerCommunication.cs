using HeroscapeTournamentServer.Classes;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace HeroscapeTournamentClient.Classes
{
    public static class ServerCommunication
    {
        private static HttpClient client = new HttpClient();
        public static FormMain? MainForm;

        public static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://localhost:5061/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static async Task<HttpResponseMessage> PingServer()
        {
            HttpResponseMessage response;

            try
            {
                response = await client.GetAsync($"Heroscape/GetStatus");
            }
            catch (Exception e)
            {
                Debug.WriteLine("Could not connect to server:\n" + e);
                response = new HttpResponseMessage();
                response.StatusCode = System.Net.HttpStatusCode.ServiceUnavailable;
            }

            return response;
        }
        public static async Task<PlayerPublic> Login(string _email, string _password)
        {
            PlayerPublic player = null;

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "Heroscape/PlayerLogin");
            requestMessage.Headers.Add("_email", _email);
            requestMessage.Headers.Add("_password", _password);

            var response = await client.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                player = await response.Content.ReadAsAsync<PlayerPublic>();
            }
            else
            {
                Debug.WriteLine(response.Content);
            }

            return player;
        }
        public static async Task<List<Card>> GetCardDatabase()
        {
            List<Card> cards = new List<Card>();

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "Heroscape/GetCardDatabase");
            var response = await client.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode )
            {
                cards = await response.Content.ReadAsAsync<List<Card>>();
            }
            else
            {
                Debug.WriteLine(response.Content);
            }

            return cards;
        }
        public static async Task<List<Tournament>> GetTournaments()
        {
            List<Tournament> tournaments = new List<Tournament>();

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "Heroscape/GetTournaments");
            var response = await client.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                tournaments = await response.Content.ReadAsAsync<List<Tournament>>();
            }
            else
            {
                Debug.WriteLine(response.Content);
            }

            return tournaments;
        }
    }
}
