using System.Linq;
using BaseBallSchedule.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseballScheduleUnitTests
{
    /// <summary>
    /// For testing the Baseball Schedule Generator
    /// </summary>
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
		    var series = new Series();
			Assert.IsTrue(series.DivisionSeries.Count == 3);
	    }

	}
}
