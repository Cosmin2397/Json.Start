
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
    }
}
