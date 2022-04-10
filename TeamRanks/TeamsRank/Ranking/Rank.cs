using System;
using Newtonsoft.Json;

namespace Ranking
{
    public class Rank
    {
        public SoccerTeam[] Teams;

        public SoccerTeam GetTeam(int teamRank)
        {
            QuickSort(0, Teams.Length - 1);
            return Teams[teamRank - 1];
        }

        public int GetRank(SoccerTeam team)
        {
            QuickSort(0, Teams.Length - 1);
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
            QuickSort(0, Teams.Length - 1);
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

                QuickSort(0, Teams.Length - 1);
        }

        private int Partition(int low, int high)
        {
            int lowIndex = low - 1;
            for (int j = low; j < high; j++)
            {
                if (Teams[high].HasFewerOrEqualPoints(Teams[j]))
                {
                    lowIndex++;

                    SoccerTeam temp = Teams[lowIndex];
                    Teams[lowIndex] = Teams[j];
                    Teams[j] = temp;
                }
            }

            SoccerTeam temp1 = Teams[lowIndex + 1];
            Teams[lowIndex + 1] = Teams[high];
            Teams[high] = temp1;

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
