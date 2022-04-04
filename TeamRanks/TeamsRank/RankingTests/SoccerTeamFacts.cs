using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Ranking;

namespace RankingTests
{
    public class SoccerTeamFacts
    {
        [Fact]
        public static void ShowATeam()
        {
            SoccerTeam team = new SoccerTeam("Steaua", 25);
            string actual = team.ShowTeam(0);
            string expected = "1. Steaua 25";
            Assert.Equal(actual, expected);
        }
    }
}
