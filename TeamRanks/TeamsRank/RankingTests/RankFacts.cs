
using Ranking;
using Xunit;

namespace RankingTests
{
    public class RankFacts
    {
        [Fact]
        public static void GetTeamByPosition_WithATwoTeamsRank_Unmodified()
        {
            SoccerTeam[] teamsRank = new SoccerTeam[2]
        {
            new SoccerTeam("Steaua", 25),
            new SoccerTeam("Dinamo", 20)
        };
            Rank rank = new Rank(teamsRank);
            string actual = rank.GetTeamByPosition(1);
            string expected = "1. Steaua 25";
            Assert.Equal(actual, expected);
        }

        [Fact]
        public static void GetTeamByPosition_WithFourTeamsRank_Unmodified()
        {
            SoccerTeam[] teamsRank = new SoccerTeam[4]
        {
            new SoccerTeam("Steaua", 25),
            new SoccerTeam("Dinamo", 20),
            new SoccerTeam("Uta", 20),
            new SoccerTeam("Chiajna", 10)
        };
            Rank rank = new Rank(teamsRank);
            string actual = rank.GetTeamByPosition(3);
            string expected = "3. Uta 20";
            Assert.Equal(actual, expected);
        }

        [Fact]
        public static void GetTeamByPosition_WithSixTeamsRank_InAnUnsortedList()
        {
            SoccerTeam[] teamsRank = new SoccerTeam[6]
        {
            new SoccerTeam("Steaua", 25),
            new SoccerTeam("Botosani", 28),
            new SoccerTeam("Dinamo", 20),
            new SoccerTeam("Uta", 21),
            new SoccerTeam("Chiajna", 10),
            new SoccerTeam("Rapid", 5)
        };
            Rank rank = new Rank(teamsRank);
            string actual = rank.GetTeamByPosition(1);
            string expected = "1. Botosani 28";
            Assert.Equal(actual, expected);
        }

        [Fact]
        public static void GetTeamByPosition_WithSixTeamsRank_AfterAddANewTeam()
        {
            SoccerTeam[] teamsRank = new SoccerTeam[6]
        {
            new SoccerTeam("Steaua", 25),
            new SoccerTeam("Botosani", 28),
            new SoccerTeam("Dinamo", 20),
            new SoccerTeam("Uta", 21),
            new SoccerTeam("Chiajna", 10),
            new SoccerTeam("Rapid", 5)
        };
            Rank rank = new Rank(teamsRank);
            rank.AddNewTeam("Vaslui", 26);
            string actual = rank.GetTeamByPosition(2);
            string expected = "2. Vaslui 26";
            Assert.Equal(actual, expected);
        }

        [Fact]
        public static void GetTeamByPosition_WithSixTeamsRank_AfterANewMatch()
        {
            SoccerTeam[] teamsRank = new SoccerTeam[6]
        {
            new SoccerTeam("Steaua", 26),
            new SoccerTeam("Botosani", 28),
            new SoccerTeam("Dinamo", 20),
            new SoccerTeam("Uta", 21),
            new SoccerTeam("Chiajna", 10),
            new SoccerTeam("Rapid", 5)
        };
            Rank rank = new Rank(teamsRank);
            rank.AddNewMatch(teamsRank[0], teamsRank[1], 0, 2);
            string actual = rank.GetTeamByPosition(1);
            string expected = "1. Steaua 29";
            Assert.Equal(actual, expected);
        }

        [Fact]
        public static void AddNewTeam()
        {
            SoccerTeam[] teamsRank = new SoccerTeam[2]
        {
            new SoccerTeam("Steaua", 25),
            new SoccerTeam("Dinamo", 20)
        };
            Rank rank = new(teamsRank);
            string[] actual = rank.AddNewTeam("Rapid", 26);
            string[] expected =
            {
            "1. Rapid 26",
            "2. Steaua 25",
            "3. Dinamo 20",
            };
            Assert.Equal(actual, expected);
        }

        [Fact]
        public static void AddTwoTeams()
        {
            SoccerTeam[] teamsRank = new SoccerTeam[2]
        {
            new SoccerTeam("Steaua", 25),
            new SoccerTeam("Dinamo", 20)
        };
            Rank rank = new(teamsRank);
            rank.AddNewTeam("Rapid", 26);
            string[] actual = rank.AddNewTeam("Uta", 10);
            string[] expected =
            {
            "1. Rapid 26",
            "2. Steaua 25",
            "3. Dinamo 20",
            "4. Uta 10"
            };
            Assert.Equal(actual, expected);
        }

        [Fact]
        public static void AddTHreeNewTeams()
        {
            SoccerTeam[] teamsRank = new SoccerTeam[2]
        {
            new SoccerTeam("Steaua", 25),
            new SoccerTeam("Dinamo", 20)
        };
            Rank rank = new(teamsRank);
            rank.AddNewTeam("Rapid", 26);
            rank.AddNewTeam("Botosani", 20);
            string[] actual = rank.AddNewTeam("Uta", 10);
            string[] expected =
            {
            "1. Rapid 26",
            "2. Steaua 25",
            "3. Dinamo 20",
            "4. Botosani 20",
            "5. Uta 10"
            };
            Assert.Equal(actual, expected);
        }

        [Fact]
        public static void AddTHreeNewTeams_AfterAMatch()
        {
            SoccerTeam[] teamsRank = new SoccerTeam[2]
        {
            new SoccerTeam("Steaua", 25),
            new SoccerTeam("Dinamo", 20)
        };
            Rank rank = new(teamsRank);
            rank.AddNewMatch(teamsRank[0], teamsRank[1], 2, 0);
            rank.AddNewTeam("Rapid", 26);
            rank.AddNewTeam("Botosani", 20);
            string[] actual = rank.AddNewTeam("Uta", 10);
            string[] expected =
            {
            "1. Steaua 28",
            "2. Rapid 26",
            "3. Dinamo 20",
            "4. Botosani 20",
            "5. Uta 10"
            };
            Assert.Equal(actual, expected);
        }

        [Fact]
        public static void GetTeamByName()
        {
            SoccerTeam[] teamsRank = new SoccerTeam[2]
        {
            new SoccerTeam("Steaua", 25),
            new SoccerTeam("Dinamo", 20)
        };
            Rank rank = new Rank(teamsRank);
            string actual = rank.GetTeamByName("Steaua");
            string expected = "1. Steaua 25";
            Assert.Equal(actual, expected);
        }

        [Fact]
        public static void AddNewMatch()
        {
            SoccerTeam[] teamsRank = new SoccerTeam[2]
        {
            new SoccerTeam("Steaua", 25),
            new SoccerTeam("Dinamo", 20)
        };
            Rank rank = new Rank(teamsRank);
            rank.AddNewMatch(teamsRank[0], teamsRank[1], 2, 0);
            string[] actual = rank.ShowRank(teamsRank);
            string[] expected =
            {
            "1. Steaua 28",
            "2. Dinamo 20",
            };

            Assert.Equal(actual, expected);
        }
    }
}
