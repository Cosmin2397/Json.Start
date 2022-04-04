using System;

namespace Ranking
{
    public class Rank
    {
        SoccerTeam[] teams;

        public Rank(SoccerTeam[] teams)
        {
            this.teams = teams;
        }

        public string GetTeamByPosition(int teamRank)
        {
            return teams[teamRank - 1].ShowTeam(teamRank - 1);
        }

        public string[] AddNewTeam(string name, int points)
        {
            Array.Resize(ref teams, teams.Length + 1);
            teams[teams.Length - 1] = new SoccerTeam(name, points);
            SortTeams(teams);
            return ShowRank(teams);
        }

        public string[] ShowRank(SoccerTeam[] teams)
        {
            string[] ranks = new string[teams.Length];
            for (int i = 0; i < teams.Length; i++)
            {
                ranks[i] = teams[i].ShowTeam(i);
            }

            return ranks;
        }

        private void SortTeams(SoccerTeam[] teams)
        {
            for (int j = 0; j < teams.Length - 1; j++)
            {
                for (int i = 0; i < teams.Length - 1; i++)
                {
                    if (teams[i].HaveFewerPoints(teams[i + 1]))
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
