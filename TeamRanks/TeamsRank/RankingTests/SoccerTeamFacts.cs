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
        public static void CheckIfaTeamHaveMorePointsThanOtherTeam_IsFalse()
        {
            SoccerTeam team = new("Steaua", 25);
            SoccerTeam team2 = new("Dinamo", 20);
            bool actual = team.HasFewerPoints(team2);
            Assert.False(actual);
        }

        [Fact]
        public static void CheckIfaTeamHaveMorePointsThanOtherTeam_IsTrue()
        {
            SoccerTeam team = new("Steaua", 20);
            SoccerTeam team2 = new("Dinamo", 25);
            bool actual = team.HasFewerPoints(team2);
            Assert.True(actual);
        }

        [Fact]
        public static void CheckIfaTeamHaveMorePointsThanOtherTeam__Equal_IsFalse()
        {
            SoccerTeam team = new("Steaua", 20);
            SoccerTeam team2 = new("Dinamo", 20);
            bool actual = team.HasFewerPoints(team2);
            Assert.False(actual);
        }

        [Fact]
        public static void CheckIfAddADraw()
        {
            SoccerTeam team = new("Steaua", 20);
            team.AddDraw();
            string expected = "Steaua 21";

            Assert.Equal(team.ToString(), expected);
        }

        [Fact]
        public static void CheckIfAddAWin()
        {
            SoccerTeam team = new("Steaua", 20);
            team.AddWin();
            string expected = "Steaua 23";

            Assert.Equal(team.ToString(), expected);
        }

    }
}
