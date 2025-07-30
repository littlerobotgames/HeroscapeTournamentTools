using HeroscapeTournamentServer.Classes;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using System.Numerics;

namespace HeroscapeTournamentClient.Classes
{
    public static class ServerCommunication
    {
        private static HttpClient client = new HttpClient();
        public static FormMain? MainForm;
        public static string Root = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static string Password = "I-rolled-all-blanks";

        public static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://73.98.248.103:5000/");
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

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "Heroscape/PlayerLogin");
            Credentials credentials = new Credentials();
            credentials.Email = _email;
            credentials.Password = _password;

            requestMessage.Content = new StringContent(JsonSerializer.Serialize(credentials), Encoding.UTF8, "application/json");

            var response = await client.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                player = await response.Content.ReadAsAsync<PlayerPublic>();
            }
            else
            {
                Debug.WriteLine(response.StatusCode.ToString());
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

            string text = JsonSerializer.Serialize(cards);

            if (!Directory.Exists(Root + "/HeroscapeTournamentClient"))
            {
                Directory.CreateDirectory(Root + "/HeroscapeTournamentClient");
            }
            File.WriteAllText(Root + "/HeroscapeTournamentClient/data_figures.json", text);

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
                Debug.WriteLine(response.StatusCode.ToString());
            }

            return tournaments;
        }
        public static async Task<List<Army>> GetPlayerArmies(int _playerId)
        {
            List<Army> armies = new List<Army>();

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "Heroscape/GetPlayerArmies");
            requestMessage.Headers.Add("playerId", _playerId.ToString());
            var response = await client.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                armies = await response.Content.ReadAsAsync<List<Army>>();
            }
            else
            {
                Debug.WriteLine(response.Content);
            }
            
            return armies;
        }
        public static async Task<string> GetDatabaseVersion()
        {
            string ver = "";

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "Heroscape/GetDatabaseVersion");
            var response = await client.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                ver = response.Content.ReadAsStringAsync().ToString();
            }
            else
            {
                Debug.WriteLine(response.Content);
            }

            return ver;
        }
        public static async Task<bool> TournamentSubmitCode(int _tourny, int _code)
        {
            bool success = false;

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "Heroscape/TournamentCodeSubmit");
            requestMessage.Headers.Add("tourneyId", _tourny.ToString());
            requestMessage.Headers.Add("code", _code.ToString());

            var response = await client.SendAsync(requestMessage);
            

            if (response.IsSuccessStatusCode)
            {
                success = await response.Content.ReadAsAsync<bool>();
            }
            else
            {
                Debug.WriteLine(response.Content);
                return false;
            }

            return success;
        }
        public static async Task<bool> ProfileCreateNew(string _fname, string _lname, string _email, string _password)
        {
            bool success = false;

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "Heroscape/NewPlayer");

            requestMessage.Headers.Add("firstname", _fname);
            requestMessage.Headers.Add("lastname", _lname);
            requestMessage.Headers.Add("email", _email);
            requestMessage.Headers.Add("password",  _password);

            var response = await client.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                success = await response.Content.ReadAsAsync<bool>();
            }
            else
            {
                Debug.WriteLine(response.Content);
                return false;
            }

            return success;
        }
        public static async Task<FigureCollection> GetTournamentAvailable(int _tourneyId)
        {
            FigureCollection availableFigures = new FigureCollection();
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "Heroscape/GetAvailableFigures");

            requestMessage.Headers.Add("_tournamentId", _tourneyId.ToString());

            var response = await client.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                availableFigures = await response.Content.ReadAsAsync<FigureCollection>();
            }
            else
            {
                Debug.WriteLine(response.Content);
            }

            return availableFigures;
        }
        public static async Task<int> SaveArmy(Army _army)
        {
            int result = -1;

            var requestMessage = new HttpRequestMessage(HttpMethod.Patch, "Heroscape/UpdateArmy");
            requestMessage.Content = new StringContent(JsonSerializer.Serialize(_army), Encoding.UTF8, "application/json");

            var response = await client.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<int>();
            }
            else
            {
                Debug.WriteLine(response.StatusCode.ToString());
            }

            return result;
        }
        public static async Task<bool> SubmitArmy(int TournamentId, int PlayerID, int ArmyId)
        {
            bool result = false;

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "Heroscape/NewTournyEntry");
            requestMessage.Headers.Add("_tournamentId", TournamentId.ToString());
            requestMessage.Headers.Add("_playerId", PlayerID.ToString());
            requestMessage.Headers.Add("_armyId", ArmyId.ToString());

            var response = await client.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<bool>();
            }
            else
            {
                Debug.WriteLine(response.StatusCode.ToString());
            }

            return result;
        }
        static string EncryptString(string plaintext, string password)
        {
            // Convert the plaintext string to a byte array
            byte[] plaintextBytes = System.Text.Encoding.UTF8.GetBytes(plaintext);

            // Derive a new password using the PBKDF2 algorithm and a random salt
            Rfc2898DeriveBytes passwordBytes = new Rfc2898DeriveBytes(password, 20);

            // Use the password to encrypt the plaintext
            Aes encryptor = Aes.Create();
            encryptor.BlockSize = 128;
            encryptor.Key = passwordBytes.GetBytes(32);
            encryptor.IV = passwordBytes.GetBytes(16);
            encryptor.Padding = PaddingMode.PKCS7;

            using MemoryStream ms = new MemoryStream();
            using CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(plaintextBytes, 0, plaintextBytes.Length);
            cs.FlushFinalBlock();
            
            return Encoding.Unicode.GetString(ms.ToArray());
        }
    }
}
