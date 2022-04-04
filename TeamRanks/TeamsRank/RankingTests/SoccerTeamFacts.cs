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

        [Fact]
        public static void ShowATeam_InATwoTeamsArray()
        {
            SoccerTeam[] teams = new SoccerTeam[2]
             {
                new SoccerTeam("Steaua", 25),
                new SoccerTeam("CFR Cluj", 14),
            };

            string actual = teams[1].ShowTeam(1);
            string expected = "2. CFR Cluj 14";
            Assert.Equal(actual, expected);
        }

        [Fact]
        public static void ShowATeam_InAFourTeamsArray()
        {
            SoccerTeam[] teams = new SoccerTeam[4]
             {
                new SoccerTeam("Steaua", 38),
                new SoccerTeam("CFR Cluj", 30),
                new SoccerTeam("Uta", 25),
                new SoccerTeam("Mioveni", 14),
            };

            string actual = teams[3].ShowTeam(3);
            string expected = "4. Mioveni 14";
            Assert.Equal(actual, expected);
        }

        [Fact]
        public static void ShowATeam_InAFiveTeamsArray()
        {
            SoccerTeam[] teams = new SoccerTeam[5]
             {
                new SoccerTeam("Steaua", 38),
                new SoccerTeam("CFR Cluj", 30),
                new SoccerTeam("Uta", 25),
                new SoccerTeam("Mioveni", 14),
                new SoccerTeam("Rapid", 5)
            };

            string actual = teams[2].ShowTeam(2);
            string expected = "3. Uta 25";
            Assert.Equal(actual, expected);
        }

        [Fact]
        public static void CheckIfaTeamHaveMorePointsThanOtherTeam_IsFalse()
        {
            SoccerTeam team = new SoccerTeam("Steaua", 25);
            SoccerTeam team2 = new SoccerTeam("Dinamo", 20);
            bool actual = team.HaveFewerPoints(team2);
            Assert.False(actual);
        }

        [Fact]
        public static void CheckIfaTeamHaveMorePointsThanOtherTeam_IsTrue()
        {
            SoccerTeam team = new SoccerTeam("Steaua", 20);
            SoccerTeam team2 = new SoccerTeam("Dinamo", 25);
            bool actual = team.HaveFewerPoints(team2);
            Assert.True(actual);
        }

        [Fact]
        public static void CheckIfaTeamHaveMorePointsThanOtherTeam__Equal_IsFalse()
        {
            SoccerTeam team = new SoccerTeam("Steaua", 20);
            SoccerTeam team2 = new SoccerTeam("Dinamo", 20);
            bool actual = team.HaveFewerPoints(team2);
            Assert.False(actual);
        }

        [Fact]
        public static void CheckIfaTeamHaveSameNameAsOtherTeam_IsTrue()
        {
            SoccerTeam team = new SoccerTeam("Steaua", 25);
            bool actual = team.IsTeamName("Steaua");
            Assert.True(actual);
        }

        [Fact]
        public static void CheckIfaTeamHaveSameNameAsOtherTeam_IsFalse()
        {
            SoccerTeam team = new SoccerTeam("Steaua", 25);
            bool actual = team.IsTeamName("steaua");
            Assert.False(actual);
        }

        [Fact]
        public static void CheckIfaTeamHaveSameNameAsOtherTeam_Null_IsFalse()
        {
            SoccerTeam team = new SoccerTeam("Steaua", 25);
            bool actual = team.IsTeamName(null);
            Assert.False(actual);
        }

        [Fact]
        public static void CheckIfaTeamHaveSameNameAsOtherTeam_EmptyString_IsFalse()
        {
            SoccerTeam team = new SoccerTeam("Steaua", 25);
            bool actual = team.IsTeamName(string.Empty);
            Assert.False(actual);
        }

        [Fact]
        public static void AddOnePointToATeam()
        {
            SoccerTeam team = new SoccerTeam("Steaua", 25);
            team.AddPoints(1);
            string actual = team.ShowTeam(0);
            string expected = "1. Steaua 26";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public static void AddThreePointsToATeam()
        {
            SoccerTeam team = new SoccerTeam("Steaua", 25);
            team.AddPoints(3);
            string actual = team.ShowTeam(0);
            string expected = "1. Steaua 28";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public static void AddTenPointsToATeam()
        {
            SoccerTeam team = new SoccerTeam("Steaua", 25);
            team.AddPoints(10);
            string actual = team.ShowTeam(0);
            string expected = "1. Steaua 35";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public static void DecreaseThreePointsToATeam()
        {
            SoccerTeam team = new SoccerTeam("Steaua", 25);
            team.AddPoints(-3);
            string actual = team.ShowTeam(0);
            string expected = "1. Steaua 25";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public static void AddZeroToTeamPoints()
        {
            SoccerTeam team = new SoccerTeam("Steaua", 25);
            team.AddPoints(0);
            string actual = team.ShowTeam(0);
            string expected = "1. Steaua 25";
            Assert.Equal(expected, actual);
        }
    }
}
