using System;
using Newtonsoft.Json;

namespace Ranking
{
    public class Rank
    {
        public SoccerTeam[] Teams;

        public SoccerTeam GetTeam(int teamRank)
        {
            SortTeams();
            return Teams[teamRank - 1];
        }

        public int GetRank(SoccerTeam team)
        {
            SortTeams();
            for (int i = 0; i < Teams.Length; i++)
            {
                if (Teams[i].Equals(team))
                {
                    return i + 1;
                }
            }

            return -1;
        }

        public void Add(SoccerTeam team)
        {
            Array.Resize(ref Teams, Teams.Length + 1);
            Teams[Teams.Length - 1] = team;
            SortTeams();
        }

        public void AddNewMatch(SoccerTeam homeTeam, SoccerTeam awayTeam, int homeTeamGoals, int awayTeamGoals)
        {
                if (homeTeamGoals > awayTeamGoals)
                {
                    homeTeam.AddWin();
                }
                else if (awayTeamGoals > homeTeamGoals)
                {
                    awayTeam.AddWin();
                }
                else
                {
                    homeTeam.AddDraw();
                    awayTeam.AddDraw();
                }

                SortTeams();
        }

        private void SortTeams()
        {
            for (int j = 0; j < Teams.Length - 1; j++)
            {
                for (int i = 0; i < Teams.Length - 1; i++)
                {
                    if (Teams[i].HasFewerPoints(Teams[i + 1]))
                    {
                        SoccerTeam temp = Teams[i + 1];
                        Teams[i + 1] = Teams[i];
                        Teams[i] = temp;
                    }
                }
            }
        }
    }
}
