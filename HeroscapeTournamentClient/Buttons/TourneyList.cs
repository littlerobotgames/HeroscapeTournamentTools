using HeroscapeTournamentClient.Classes;
using HeroscapeTournamentClient.Pages;
using HeroscapeTournamentServer.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeroscapeTournamentClient.Buttons
{
    public partial class TourneyList : UserControl
    {
        public List<Tournament> tournaments = new List<Tournament>();
        public TournamentDetailPanel TournamentDetailPanel { get; set; }
        public Page_Battle battlePage;
        public TourneyList()
        {
            InitializeComponent();
        }

        private void TourneyListOnLoad(object sender, EventArgs e)
        {
            UpdateTournaments();
        }
        private async void UpdateTournaments()
        {
            var response = await ServerCommunication.GetTournaments();
            tournaments = response;

            while(Controls.Count > 0)
            {
                Controls[0].Dispose();
            }

            int place_y = 25;
            foreach(Tournament tournament in tournaments)
            {
                TournamentCard tCard = new TournamentCard(this, tournament.id);

                tCard.labelName.Text = tournament.name;

                if (tournament.entrants_max == 0)
                {
                   
                    tCard.labelParticipants.Text = $"{tournament.entries.Count} Participant";

                    if (tournament.entries.Count > 1)
                    {
                        tCard.labelParticipants.Text += "s";
                    }
                }
                else
                {
                    tCard.labelParticipants.Text = $"{tournament.entries.Count}/{tournament.entrants_max} Participant";

                    if (tournament.entries.Count > 1)
                    {
                        tCard.labelParticipants.Text += "s";
                    }
                }

                tCard.labelDate.Text = $"{Globals.MonthNames[tournament.month]} {tournament.day}, {tournament.year} - {tournament.time}";
                tCard.Location = new Point(25, place_y);

                place_y += 175;

                Controls.Add(tCard);
            }
        }
        public void UpdateTournamentViewer(int tournamentId)
        {
            TournamentDetailPanel.Visible = true;
            battlePage.buttonEnter.Enabled = true;
            battlePage.buttonEnter.Visible = true;

            Tournament thisTourney = tournaments[tournamentId];

            TournamentDetailPanel.labelName.Text = thisTourney.name;
            TournamentDetailPanel.labelHexes.Text = $"{thisTourney.hexes_max} (+{thisTourney.hexes_flex}) Hexes";
            TournamentDetailPanel.labelPoints.Text = $"{thisTourney.points} (+{thisTourney.point_flex}) Points";
            TournamentDetailPanel.labelDate.Text = $"{Globals.MonthNames[thisTourney.month]} {thisTourney.day}, {thisTourney.year} - {thisTourney.time}";
            TournamentDetailPanel.labelFormat.Text = Globals.FormatNames[(int)thisTourney.format];
            
            if (thisTourney.entrants_max == 0)
            {

                TournamentDetailPanel.labelParticipants.Text = $"{thisTourney.entries.Count} Participant";

                if (thisTourney.entries.Count > 1)
                {
                    TournamentDetailPanel.labelParticipants.Text += "s";
                }
            }
            else
            {
                TournamentDetailPanel.labelParticipants.Text = $"{thisTourney.entries.Count}/{thisTourney.entrants_max} Participant";

                if (thisTourney.entries.Count > 1)
                {
                    TournamentDetailPanel.labelParticipants.Text += "s";
                }
            }

            if (thisTourney.join_code != 0)
            {
                TournamentDetailPanel.labelPublicity.Text = "Private Admission";
            }
            else
            {
                TournamentDetailPanel.labelParticipants.Text = "Public Admission";
            }
        }
    }
}
