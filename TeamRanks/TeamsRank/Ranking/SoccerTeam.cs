using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranking
{
    public class SoccerTeam
    {
        readonly int winnerPoints = 3;
        private readonly string name;
        private int teamPoints;

        public SoccerTeam(string name, int teamPoints)
        {
            this.name = name;
            this.teamPoints = teamPoints;
        }

        public bool HasFewerOrEqualPoints(SoccerTeam nextTeam)
        {
            if (nextTeam == null)
            {
                return false;
            }

            return teamPoints <= nextTeam.teamPoints;
        }

        public void AddWin()
        {
            this.teamPoints += winnerPoints;
        }

        public void AddDraw()
        {
            this.teamPoints++;
        }
    }
}