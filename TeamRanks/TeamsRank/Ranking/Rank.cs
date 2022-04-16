using System;
using Newtonsoft.Json;

namespace Ranking
{
    public class Rank
    {
        private SoccerTeam[] teams = new SoccerTeam[0];

        public void Add(SoccerTeam team)
        {
            Array.Resize(ref teams, teams.Length + 1);
            teams[teams.Length - 1] = team;
            QuickSort(0, teams.Length - 1);
        }

        public SoccerTeam GetTeam(int teamRank)
        {
            return teams[teamRank - 1];
        }

        public int GetRank(SoccerTeam team)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i].Equals(team))
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

                QuickSort(0, teams.Length - 1);
        }

        private int Partition(int low, int high)
        {
            int lowIndex = low - 1;
            for (int j = low; j < high; j++)
            {
                if (teams[high].HasFewerOrEqualPoints(teams[j]))
                {
                    lowIndex++;

                    SoccerTeam temp = teams[lowIndex];
                    teams[lowIndex] = teams[j];
                    teams[j] = temp;
                }
            }

            SoccerTeam temp1 = teams[lowIndex + 1];
            teams[lowIndex + 1] = teams[high];
            teams[high] = temp1;

            return lowIndex + 1;
        }

        private void QuickSort(int low, int high)
        {
            if (low >= high)
            {
                return;
            }

            int partitionIndex = Partition(low, high);

            QuickSort(low, partitionIndex - 1);
            QuickSort(partitionIndex + 1, high);
        }
    }
}
