using System;

namespace Ranking
{
    public class Rank
    {
        private SoccerTeam[] teams = new SoccerTeam[0];

        public void Add(SoccerTeam team)
        {
            Array.Resize(ref teams, teams.Length + 1);
            teams[teams.Length - 1] = team;
            Sort();
        }

        public SoccerTeam GetTeam(int teamRank)
        {
            return teams[teamRank - 1];
        }

        public int GetRank(SoccerTeam team)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i] == team)
                {
                    return i + 1;
                }
            }

            return -1;
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

                Sort();
        }

        private void Sort()
        {
            for (int i = 1; i < teams.Length; ++i)
            {
                SoccerTeam temp = teams[i];
                int j = i - 1;
                while (j >= 0 && teams[j].HasFewerPoints(temp))
                {
                    teams[j + 1] = teams[j];
                    j--;
                }

                teams[j + 1] = temp;
            }
        }
    }
}
