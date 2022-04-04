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
    }
}
