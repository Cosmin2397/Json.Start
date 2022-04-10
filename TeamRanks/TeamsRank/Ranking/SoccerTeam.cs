using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranking
{
    public class SoccerTeam : IEquatable<SoccerTeam>
    {
        readonly int winnerPoints = 3;
        private readonly string name;
        private int teamPoints;

        public SoccerTeam(string name, int teamPoints)
        {
            this.name = name;
            this.teamPoints = teamPoints;
        }

        public bool HasFewerPoints(SoccerTeam nextTeam)
        {
            if (nextTeam == null)
            {
                return false;
            }

            return teamPoints < nextTeam.teamPoints;
        }

        public void AddWin()
            {
            this.teamPoints += winnerPoints;
        }

        public void AddDraw()
        {
            this.teamPoints++;
        }

        public bool Equals(SoccerTeam other)
        {
            return other != null && name == other.name && teamPoints == other.teamPoints;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as SoccerTeam);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, teamPoints);
        }
    }
}