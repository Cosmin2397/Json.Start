
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
            rank.Teams =  new SoccerTeam[2]
        {
            new SoccerTeam("Steaua", 25),
            new SoccerTeam("Dinamo", 20)
        };
            SoccerTeam actual = rank.GetTeam(1);
            SoccerTeam expected = new("Steaua", 25);
            Assert.Equal(actual, expected);
        }

        [Fact]
        public static void GetTeamByPosition_WithFourTeamsRank_Unmodified()
        {
            Rank rank = new();
            rank.Teams  = new SoccerTeam[4]
        {
            new SoccerTeam("Steaua", 25),
            new SoccerTeam("Dinamo", 20),
            new SoccerTeam("Uta", 20),
            new SoccerTeam("Chiajna", 10)
        };
            SoccerTeam actual = rank.GetTeam(3);
            SoccerTeam expected = new("Uta", 20);
            Assert.Equal(actual, expected);
        }

        [Fact]
        public static void GetTeamByPosition_WithSixTeamsRank_InAnUnsortedList()
        { 
        Rank rank = new();
        rank.Teams = new SoccerTeam[6]
        {
            new SoccerTeam("Steaua", 25),
            new SoccerTeam("Botosani", 28),
            new SoccerTeam("Dinamo", 20),
            new SoccerTeam("Uta", 21),
            new SoccerTeam("Chiajna", 10),
            new SoccerTeam("Rapid", 5)
        };
            SoccerTeam actual = rank.GetTeam(1);
            SoccerTeam expected = new("Botosani", 28);
            Assert.Equal(actual, expected);
        }

        [Fact]
        public static void GetTeamByPosition_WithSixTeamsRank_AfterAddANewTeam()
        {
            Rank rank = new();
            rank.Teams  = new SoccerTeam[6]
        {
            new SoccerTeam("Steaua", 25),
            new SoccerTeam("Botosani", 28),
            new SoccerTeam("Dinamo", 20),
            new SoccerTeam("Uta", 21),
            new SoccerTeam("Chiajna", 10),
            new SoccerTeam("Rapid", 5)
        };
            rank.Add(new SoccerTeam("Vaslui", 26));
            SoccerTeam actual = rank.GetTeam(2);
            SoccerTeam expected = new("Vaslui", 26);
            Assert.Equal(actual, expected);
        }

        [Fact]
        public static void GetTeamByPosition_WithSixTeamsRank_AfterANewMatch()
        {
            Rank rank = new();
            rank.Teams = new SoccerTeam[6]
        {
            new SoccerTeam("Steaua", 26),
            new SoccerTeam("Botosani", 28),
            new SoccerTeam("Dinamo", 20),
            new SoccerTeam("Uta", 21),
            new SoccerTeam("Chiajna", 10),
            new SoccerTeam("Rapid", 5)
        };
            rank.AddNewMatch(rank.Teams[0], rank.Teams[1], 2, 1);
            SoccerTeam actual = rank.GetTeam(1);
            SoccerTeam expected = new("Steaua", 29);
            Assert.Equal(actual, expected);
        }

        [Fact]
        public static void AddNewTeam()
        {
            Rank rank = new();
            rank.Teams = new SoccerTeam[2]
        {
            new SoccerTeam("Steaua", 25),
            new SoccerTeam("Dinamo", 20)
        };
            rank.Add(new SoccerTeam("Rapid", 26));
            SoccerTeam expected = new("Rapid", 26);
            Assert.Equal(rank.Teams[0], expected);
        }

        [Fact]
        public static void AddNewTeam_AfterAMatch()
        {
            Rank rank = new();
            rank.Teams = new SoccerTeam[2]
        {
            new SoccerTeam("Steaua", 25),
            new SoccerTeam("Dinamo", 20)
        };
            rank.AddNewMatch(rank.Teams[0], rank.Teams[1], 2, 0);
            rank.Add(new SoccerTeam("Rapid", 26));
            SoccerTeam expected= new("Rapid", 26);
            Assert.Equal(rank.Teams[1], expected);
        }

        [Fact]
        public static void GetTeamByName()
        {
            Rank rank = new();
            rank.Teams = new SoccerTeam[2]
        {
            new SoccerTeam("Steaua", 25),
            new SoccerTeam("Dinamo", 20)
        };
            int actual = rank.GetRank(new SoccerTeam("Dinamo", 20));
            int expected = 2;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public static void GetTeamByName_WithLowerCase()
        {
            Rank rank = new();
            rank.Teams = new SoccerTeam[2]
        {
            new SoccerTeam("Steaua", 25),
            new SoccerTeam("Dinamo", 20)
        };
            int actual = rank.GetRank(new SoccerTeam("steaua", 25));
            int expected = -1;
            Assert.Equal(actual, expected);
        }

        [Fact]
        public static void GetTeamByName_AfterAMatch()
        {
            Rank rank = new();
            rank.Teams = new SoccerTeam[2]
        {
            new SoccerTeam("Steaua", 25),
            new SoccerTeam("Dinamo", 23)
        };
            rank.AddNewMatch(rank.Teams[0], rank.Teams[1], 0, 3);
            int actual = rank.GetRank(new SoccerTeam("Dinamo", 26));
            int expected = 1;
            Assert.Equal(actual, expected);
        }

        [Fact]
        public static void GetTeamByName_AfterAddANewTeamAndAMatch()
        {
            Rank rank = new();
            rank.Teams = new SoccerTeam[2]
        {
            new SoccerTeam("Steaua", 25),
            new SoccerTeam("Dinamo", 23)
        };
            rank.AddNewMatch(rank.Teams[0], rank.Teams[1], 0, 3);
            rank.Add(new SoccerTeam("Botosani", 20));
            int actual = rank.GetRank(new SoccerTeam("Botosani", 20));
            int expected = 3;
            Assert.Equal(actual, expected);
        }
        [Fact]
        public static void AddNewMatch_FirstTeamWin()
        {
            Rank rank = new();
            rank.Teams = new SoccerTeam[2]
        {
            new SoccerTeam("Steaua", 25),
            new SoccerTeam("Dinamo", 20)
        };

            rank.AddNewMatch(rank.Teams[0], rank.Teams[1], 2, 0);
            SoccerTeam expected = new("Steaua", 28);
            Assert.Equal(rank.Teams[0], expected);
        }

        [Fact]
        public static void AddNewMatch_SecondTeamWin()
        {
            Rank rank = new();
            rank.Teams = new SoccerTeam[2]
        {
            new SoccerTeam("Steaua", 25),
            new SoccerTeam("Dinamo", 23)
        };
            rank.AddNewMatch(rank.Teams[0], rank.Teams[1], 0 , 2);
            SoccerTeam expected = new("Dinamo", 26);
            Assert.Equal(rank.Teams[0], expected);
        }
        [Fact]
        public static void AddTwoGames()
        {
            Rank rank = new();
            rank.Teams = new SoccerTeam[2]
        {
            new SoccerTeam("Steaua", 25),
            new SoccerTeam("Dinamo", 20)
        };
            rank.AddNewMatch(rank.Teams[0], rank.Teams[1], 0, 2);
            rank.AddNewMatch(rank.Teams[0], rank.Teams[1], 2, 0);
            SoccerTeam expected = new("Steaua", 28);
            Assert.Equal(rank.Teams[0], expected);
        }

        [Fact]
        public static void AddNewMatch_Equal()
        {
            Rank rank = new();
            rank.Teams = new SoccerTeam[2]
        {
            new SoccerTeam("Steaua", 25),
            new SoccerTeam("Dinamo", 20)
        };
            rank.AddNewMatch(rank.Teams[0], rank.Teams[1], 0, 0);
            SoccerTeam expected = new("Steaua", 26);
            Assert.Equal(rank.Teams[0], expected);
        }
    }
}
