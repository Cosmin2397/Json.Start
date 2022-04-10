using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Ranking;
using Newtonsoft.Json;

namespace RankingTests
{
    public class SoccerTeamFacts
    {

        [Fact]
        public static void CheckIfaTeamHaveMorePointsThanOtherTeam_IsFalse()
        {
            SoccerTeam team = new("Steaua", 25);
            SoccerTeam team2 = new("Dinamo", 20);
            bool actual = team.HasFewerOrEqualPoints(team2);
            Assert.False(actual);
        }

        [Fact]
        public static void CheckIfaTeamHaveMorePointsThanOtherTeam_IsTrue()
        {
            SoccerTeam team = new("Steaua", 20);
            SoccerTeam team2 = new("Dinamo", 25);
            bool actual = team.HasFewerOrEqualPoints(team2);
            Assert.True(actual);
        }

        [Fact]
        public static void CheckIfaTeamHaveMorePointsThanOtherTeam__Equal_IsFalse()
        {
            SoccerTeam team = new("Steaua", 20);
            SoccerTeam team2 = new("Dinamo", 20);
            bool actual = team.HasFewerOrEqualPoints(team2);
            Assert.True(actual);
        }

        [Fact]
        public static void CheckIfAddADraw()
        {
            SoccerTeam team = new("Steaua", 20);
            team.AddDraw();
            SoccerTeam expectedTeam = new("Steaua", 21);
            var actual = JsonConvert.SerializeObject(team);
            var expected = JsonConvert.SerializeObject(expectedTeam);
            Assert.Equal(actual, expected);
        }

        [Fact]
        public static void CheckIfAddAWin()
        {
            SoccerTeam team = new("Steaua", 20);
            team.AddWin();
            SoccerTeam expectedTeam = new("Steaua", 23);
            var actual = JsonConvert.SerializeObject(team);
            var expected = JsonConvert.SerializeObject(expectedTeam);
            Assert.Equal(actual, expected);
        }

    }
}
