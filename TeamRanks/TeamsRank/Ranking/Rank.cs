using System;

namespace Ranking
{
    public class Rank
    {
        SoccerTeam[] teams;

        public Rank()
        {
            teams = new SoccerTeam[teams.Length];
        }

        public SoccerTeam GetTeam(int teamRank)
        {
            SortTeams();
            return teams[teamRank - 1];
        }

        public int GetRank(SoccerTeam team)
        {
            SortTeams();
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i] == team)
                {
                    return i + 1;
                }
            }

            return -1;
        }

        public void Add(SoccerTeam team)
        {
            Array.Resize(ref teams, teams.Length + 1);
            teams[teams.Length - 1] = team;
            SortTeams();
        }

        public void AddNewMatch(SoccerTeam homeTeam, SoccerTeam awayTeam, int homeTeamGoals, int awayTeamGoals)
        {
            if (homeTeamGoals >= 0 && awayTeamGoals >= 0)
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
            }

            SortTeams();
        }

        private void SortTeams()
        {
            for (int j = 0; j < teams.Length - 1; j++)
            {
                for (int i = 0; i < teams.Length - 1; i++)
                {
                    if (teams[i].HasFewerPoints(teams[i + 1]))
                    {
                        SoccerTeam temp = teams[i + 1];
                        teams[i + 1] = teams[i];
                        teams[i] = temp;
                    }
                }
            }
        }
    }
}
