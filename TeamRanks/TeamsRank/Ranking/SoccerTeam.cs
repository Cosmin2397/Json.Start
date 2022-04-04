using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranking
{
    public class SoccerTeam
    {
        readonly string name;
        private int teamPoints;

        public SoccerTeam(string name, int teamPoints)
        {
            this.name = name;
            this.teamPoints = teamPoints;
        }

        public string ShowTeam(int rank)
        {
            return (rank + 1).ToString() + ". " + name + " " + teamPoints;
        }
    }
}