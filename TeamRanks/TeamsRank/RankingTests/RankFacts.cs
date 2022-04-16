
using Ranking;
using Xunit;

namespace RankingTests
{
    public class RankFacts
    {
        [Fact]
        public static void GetTeamByPosition_WithATwoTeamsRank_Unmodified()
        {
            Rank rank = new();
            SoccerTeam firstTeam = new("Steaua", 25);
            SoccerTeam secondTeam = new("Dinamo", 20);
            rank.Add(firstTeam);
            rank.Add(secondTeam);
            SoccerTeam actual = rank.GetTeam(1);
            Assert.Equal(actual, firstTeam);
        }

        [Fact]
        public static void GetTeamByPosition_WithFourTeamsRank_Unmodified()
        {
            Rank rank = new();
            SoccerTeam firstTeam = new("Steaua", 25);
            SoccerTeam secondTeam = new("Dinamo", 20);
            SoccerTeam thirdTeam = new("Uta", 20);
            SoccerTeam fourthTeam = new("Chiajna", 10);
            rank.Add(firstTeam);
            rank.Add(secondTeam);
            rank.Add(thirdTeam);
            rank.Add(fourthTeam);
            SoccerTeam actual = rank.GetTeam(3);
            Assert.Equal(actual, thirdTeam);
        }

        [Fact]
        public static void GetTeamByPosition_WithSixTeamsRank_InAnUnsortedList()
        { 
        Rank rank = new();
            SoccerTeam firstTeam = new("Steaua", 25);
            SoccerTeam secondTeam = new("Dinamo", 20);
            SoccerTeam thirdTeam = new("Botosani", 28);
            SoccerTeam fourthTeam = new("Chiajna", 10);
            rank.Add(firstTeam);
            rank.Add(secondTeam);
            rank.Add(thirdTeam);
            rank.Add(fourthTeam);
            SoccerTeam actual = rank.GetTeam(1);
            Assert.Equal(actual, thirdTeam);
        }

        [Fact]
        public static void GetTeamByPosition_WithSixTeamsRank_AfterAddANewTeam()
        {
            Rank rank = new();
            SoccerTeam firstTeam = new("Steaua", 25);
            SoccerTeam secondTeam = new("Dinamo", 20);
            SoccerTeam thirdTeam = new("Botosani", 28);
            SoccerTeam fourthTeam = new("Chiajna", 10);
            rank.Add(firstTeam);
            rank.Add(secondTeam);
            rank.Add(thirdTeam);
            rank.Add(fourthTeam);
            SoccerTeam lastTeam = new("Vaslui", 26);
            rank.Add(lastTeam);
            SoccerTeam actual = rank.GetTeam(2);
            Assert.Equal(lastTeam, actual);
        }

        [Fact]
        public static void GetTeamByPosition_WithSixTeamsRank_AfterANewMatch()
        {
            Rank rank = new();
            SoccerTeam firstTeam = new("Steaua", 26);
            SoccerTeam secondTeam = new("Dinamo", 20);
            SoccerTeam thirdTeam = new("Botosani", 28);
            SoccerTeam fourthTeam = new("Chiajna", 10);
            rank.Add(firstTeam);
            rank.Add(secondTeam);
            rank.Add(thirdTeam);
            rank.Add(fourthTeam);
            rank.AddNewMatch(rank.GetTeam(2), rank.GetTeam(1), 2, 1);
            SoccerTeam actual = rank.GetTeam(1);
            Assert.Equal(actual, firstTeam);
        }

        [Fact]
        public static void AddNewTeam()
        {
            Rank rank = new();
            SoccerTeam firstTeam = new("Steaua", 25);
            SoccerTeam secondTeam = new("Dinamo", 20);
            SoccerTeam thirdTeam = new("Botosani", 24);
            rank.Add(firstTeam);
            rank.Add(secondTeam);
            rank.Add(thirdTeam);
            SoccerTeam fourthTeam = new("Rapid", 26);
            rank.Add(fourthTeam);
            Assert.Equal(rank.GetTeam(1), fourthTeam);
        }

        [Fact]
        public static void AddNewTeam_AfterAMatch()
        {
            Rank rank = new();
            SoccerTeam firstTeam = new("Steaua", 25);
            SoccerTeam secondTeam = new("Dinamo", 20);
            rank.Add(firstTeam);
            rank.Add(secondTeam);
            rank.AddNewMatch(rank.GetTeam(1), rank.GetTeam(2), 2, 0);
            SoccerTeam thirdTeam = new("Rapid", 26);
            rank.Add(thirdTeam);
            Assert.Equal(rank.GetTeam(2), thirdTeam);
        }

        [Fact]
        public static void GetTeamByName()
        {
            Rank rank = new();
            SoccerTeam firstTeam = new("Steaua", 25);
            SoccerTeam secondTeam = new("Dinamo", 20);
            rank.Add(firstTeam);
            rank.Add(secondTeam);
            int actual = rank.GetRank(secondTeam);
            int expected = 2;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public static void GetTeamByName_WithLowerCase()
        {
            Rank rank = new();
            SoccerTeam firstTeam = new("Steaua", 25);
            SoccerTeam secondTeam = new("Dinamo", 20);
            rank.Add(firstTeam);
            rank.Add(secondTeam);
            int actual = rank.GetRank(new SoccerTeam("steaua", 25));
            int expected = -1;
            Assert.Equal(actual, expected);
        }

        [Fact]
        public static void GetTeamByName_AfterAMatch()
        {
            Rank rank = new();
            SoccerTeam firstTeam = new("Steaua", 25);
            SoccerTeam secondTeam = new("Dinamo", 23);
            rank.Add(firstTeam);
            rank.Add(secondTeam);
            rank.AddNewMatch(rank.GetTeam(1), rank.GetTeam(2), 0, 3);
            int actual = rank.GetRank(secondTeam);
            int expected = 1;
            Assert.Equal(actual, expected);
        }

        [Fact]
        public static void GetTeamByName_AfterAddANewTeamAndAMatch()
        {
            Rank rank = new();
            SoccerTeam firstTeam = new("Steaua", 25);
            SoccerTeam secondTeam = new("Dinamo", 20);
            rank.Add(firstTeam);
            rank.Add(secondTeam);
            rank.AddNewMatch(rank.GetTeam(1), rank.GetTeam(2), 0, 3);
            SoccerTeam thirdTeam = new("Botosani", 20);
            rank.Add(thirdTeam);
            int actual = rank.GetRank(thirdTeam);
            int expected = 3;
            Assert.Equal(actual, expected);
        }
        [Fact]
        public static void AddNewMatch_FirstTeamWin()
        {
            Rank rank = new();
            SoccerTeam firstTeam = new("Steaua", 25);
            SoccerTeam secondTeam = new("Dinamo", 20);
            rank.Add(firstTeam);
            rank.Add(secondTeam);
            rank.AddNewMatch(rank.GetTeam(1), rank.GetTeam(2), 2, 0);
            Assert.Equal(rank.GetTeam(1), firstTeam);
        }

        [Fact]
        public static void AddNewMatch_SecondTeamWin()
        {
            Rank rank = new();
            SoccerTeam firstTeam = new("Steaua", 25);
            SoccerTeam secondTeam = new("Dinamo", 23);
            rank.Add(firstTeam);
            rank.Add(secondTeam);
            rank.AddNewMatch(rank.GetTeam(1), rank.GetTeam(2), 0 , 2);
            Assert.Equal(rank.GetTeam(1), secondTeam);
        }
        [Fact]
        public static void AddTwoGames()
        {
            Rank rank = new();
            SoccerTeam firstTeam = new("Steaua", 25);
            SoccerTeam secondTeam = new("Dinamo", 20);
            rank.Add(firstTeam);
            rank.Add(secondTeam);
            rank.AddNewMatch(rank.GetTeam(1), rank.GetTeam(2), 0, 2);
            rank.AddNewMatch(rank.GetTeam(1), rank.GetTeam(2), 2, 0);
            Assert.Equal(rank.GetTeam(1), firstTeam);
        }

        [Fact]
        public static void AddNewMatch_Equal()
        {
            Rank rank = new();
            SoccerTeam firstTeam = new("Steaua", 25);
            SoccerTeam secondTeam = new("Dinamo", 20);
            rank.Add(firstTeam);
            rank.Add(secondTeam);
            rank.AddNewMatch(rank.GetTeam(1), rank.GetTeam(2), 0, 0);
            Assert.Equal(rank.GetTeam(1), firstTeam);
        }
    }
}
