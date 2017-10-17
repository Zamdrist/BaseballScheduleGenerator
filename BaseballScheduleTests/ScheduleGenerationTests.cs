using System;
using System.Collections.Generic;
using System.Linq;
using BaseBallSchedule.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseballScheduleUnitTests
{
	/// <summary>
	/// For testing the Baseball Schedule Generator
	/// </summary>
#if DEBUG
	[Serializable]
#endif
	[TestClass]
    public class ScheduleGenerationTests
	{

		//Arrange
		private readonly ScheduleGeneratorHelper _scheduleGeneratorHelper;

        public ScheduleGenerationTests()
		{
			//Act
			this._scheduleGeneratorHelper = new ScheduleGeneratorHelper();
		}

        private TestContext _testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return this._testContextInstance;
            }
            set
            {
                this._testContextInstance = value;
            }
        }

		#region Additional test attributes
		//
		// You can use the following additional attributes as you write your tests:
		//
		// Use ClassInitialize to run code before running the first test in the class
		// [ClassInitialize()]
		// public static void MyClassInitialize(TestContext testContext) { }
		//
		// Use ClassCleanup to run code after all tests in a class have run
		// [ClassCleanup()]
		// public static void MyClassCleanup() { }
		//
		// Use TestInitialize to run code before running each test
		// [TestInitialize()]
		// public void MyTestInitialize() { }
		//
		// Use TestCleanup to run code after each test has run
		// [TestCleanup()]
		// public void MyTestCleanup() { }
		//
		#endregion

		[TestMethod]
	    public void NumberOfNlWestDivisionTeams()
	    {
			//Assert
		    var teams = this._scheduleGeneratorHelper.NLTeams
				.Where(t => t.Division == League.Division.West);
		    Assert.IsTrue(teams.Count() == League.TeamsInDivision);
		}

		[TestMethod]
	    public void NumberOfNlEastDivisionTeams()
	    {
		    var teams = this._scheduleGeneratorHelper.NLTeams
				.Where(t => t.Division == League.Division.East);
			Assert.IsTrue(teams.Count() == League.TeamsInDivision);
		}

	    [TestMethod]
	    public void NumberOfNlCentralDivisionTeams()
	    {
		    var teams = this._scheduleGeneratorHelper.NLTeams
				.Where(t => t.Division == League.Division.Central);
		    Assert.IsTrue(teams.Count() == League.TeamsInDivision);
	    }

	    [TestMethod]
	    public void NumberOfNlLeagueTeams()
	    {
		    var teams = this._scheduleGeneratorHelper.NLTeams
				.Where(t => t.League == League.Circuit.NL);
			Assert.IsTrue(teams.Count() == League.TeamsInLeague);
	    }

	    [TestMethod]
	    public void IsSameDivision()
	    {
			var homeTeam = this._scheduleGeneratorHelper.GetTeamByName("SDP");
			var awayTeam = this._scheduleGeneratorHelper.GetTeamByName("STL");
			Assert.IsFalse(homeTeam.Division == awayTeam.Division);

		}

		[TestMethod]
	    public void IsDifferentDivision()
	    {
		    var homeTeam = this._scheduleGeneratorHelper.GetTeamByName("ATL");
		    var awayTeam = this._scheduleGeneratorHelper.GetTeamByName("STL");
		    Assert.IsTrue(homeTeam.Division != awayTeam.Division);

	    }

	    [TestMethod]
	    public void IsSameLeage()
	    {
		    var homeTeam = this._scheduleGeneratorHelper.GetTeamByLeaugueId(0);
		    var awayTeam = this._scheduleGeneratorHelper.GetTeamByLeaugueId(14);
			Assert.IsTrue(homeTeam.League == awayTeam.League);
	    }

	    [TestMethod]
	    public void IsValidTeam()
	    {
		    var team = this._scheduleGeneratorHelper.GetTeamByLeaugueId(14);
		    var teams = this._scheduleGeneratorHelper.NLTeams;
			Assert.IsTrue(teams.Exists(t => t.LeagueId == team.LeagueId));
	    }

	    [TestMethod]
	    public void InvalidTeam()
	    {
			var team = this._scheduleGeneratorHelper.GetTeamByLeaugueId(15);
		    Assert.IsTrue(team == null);
		}

	    [TestMethod]
	    public void OpponentsInDivision()
	    {
		    var teams = this._scheduleGeneratorHelper.NLTeams
				.Where(t => t.Division == League.Division.West).ToList();
		    teams.Remove(teams.First(t => t.DivisionId == 0));
			Assert.IsTrue(teams.Count == League.TeamsInDivision - 1);
	    }

	    [TestMethod]
	    public void NumberOfGamesInSeries()
	    {
			var schedule = new Schedule();
		    var gameDate = schedule.OpeningDay;
			var series = new Series();
		    var nlTeams = this._scheduleGeneratorHelper.NLTeams;

			var homeTeam = this._scheduleGeneratorHelper.GetRandomLeagueTeam(League.Circuit.NL, nlTeams);
		    nlTeams.Remove(homeTeam);
			var awayTeam = this._scheduleGeneratorHelper.GetRandomLeagueTeam(League.Circuit.NL, nlTeams);

			series.DivisionSeries = new List<Game>();

		    for (var i = 0; i < Series.DivisionSeriesGames; i++)
		    {
			    series.DivisionSeries.Add(
				    new Game {GameDate = gameDate,
							  HomeTeam = homeTeam.Name,
							  AwayTeam = awayTeam.Name});
			    gameDate = gameDate.AddDays(1);
		    }

		    Assert.IsTrue(series.DivisionSeries.Count == Series.DivisionSeriesGames && homeTeam != null && awayTeam != null);
	    }

	    [TestMethod]
	    public void NumberOfDivisionHomeGames()
	    {
		    var series = new Series();
		    var totalGames = 0;
		    var rows = series.DivisionHomeGames.GetUpperBound(0);
		    var columns = series.DivisionHomeGames.GetUpperBound(1);

		    for (var r = 0; r <= rows; r++)
		    {
			    for (var c = 0; c <= columns; c++)
			    {
				    totalGames = totalGames + series.DivisionHomeGames[r, c];
			    }
		    }
			Assert.IsTrue(totalGames == 38);

	    }

	    [TestMethod]
	    public void NumerOfDivisionAwayGames()
	    {
		    var series = new Series();
		    var totalGames = 0;
		    var rows = series.DivisionAwayGames.GetUpperBound(0);
		    var columns = series.DivisionAwayGames.GetUpperBound(1);

		    for (var r = 0; r <= rows; r++)
		    {
			    for (var c = 0; c <= columns; c++)
			    {
				    totalGames = totalGames + series.DivisionAwayGames[r, c];
			    }
		    }
			Assert.IsTrue(totalGames == 38);
	    }

	    [TestMethod]
	    public void NumerOfScheduledDivisionHomeGames()
	    {
		    var schedule = new Schedule();
		    var series = new Series();
			var gameDate = schedule.OpeningDay;

		    var westDivisionTeams = this._scheduleGeneratorHelper.NLTeams.FindAll(t => t.Division == League.Division.West);
		    var homeTeam = this._scheduleGeneratorHelper.GetRandomLeagueTeamByDivision(League.Circuit.NL, League.Division.West, westDivisionTeams);
		    westDivisionTeams.Remove(homeTeam);

		    var awayTeam = new Team();
			series.DivisionSeries = new List<Game>();
			var rows = series.DivisionHomeGames.GetUpperBound(0);
		    var columns = series.DivisionHomeGames.GetUpperBound(1);

			for (var r = 0; r <= rows; r++)
		    {
			    for (var c = 0; c <= columns; c++)
			    {
				    for (var i = 0; i < series.DivisionHomeGames[r, c]; i++)
				    {
					    awayTeam = this._scheduleGeneratorHelper.GetRandomLeagueTeamByDivision(League.Circuit.NL, League.Division.West, westDivisionTeams);
						series.DivisionSeries.Add( //Schedule game here
						    new Game
						    {
							    GameDate = gameDate,
							    HomeTeam = homeTeam.Name,
							    AwayTeam = awayTeam.Name
						    });
					    gameDate = gameDate.AddDays(1);
				    }
				    westDivisionTeams.Remove(awayTeam);
			    }
			    westDivisionTeams = this._scheduleGeneratorHelper.NLTeams.FindAll(t => t.Division == League.Division.West && t != homeTeam);
		    }
		    Assert.IsTrue(series.DivisionSeries.Count == 38);

	    }

	}
}
