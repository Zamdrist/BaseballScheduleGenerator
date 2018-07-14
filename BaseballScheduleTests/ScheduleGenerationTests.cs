using System;
using System.Linq;
using BaseballSchedule.Core;
using BaseballSchedule.Core.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseballScheduleUnitTests
{
#if DEBUG
	[Serializable]
#endif
	///<summary>
	/// For testing the Baseball Schedule Generator
	/// </summary>
	[TestClass]
	public class ScheduleGenerationTests
	{


		//public ScheduleGenerationTests()
		//{

		//}

		private TestContext _testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get { return this._testContextInstance; }
			set { this._testContextInstance = value; }
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
		public void NumberOfDivisionSeriesSeries()
		{
			var series = new SeriesData();
			Assert.IsTrue(series.DivisionSeries.ToList().Count == 24);
		}

		[TestMethod]
		public void NumerOfDivisionSeriesGames()
		{
			var series = new SeriesData();
			var gameCount = series.DivisionSeries.Sum(divisionSeries => divisionSeries.Games.Count());

			Assert.IsTrue(gameCount == 76);
		}

		[TestMethod]
		public void NumberOfDivisionGames()
		{
			var series = new SeriesData();

			var homeGames = series.DivisionSeries
				.Where(s => s.Seriestype == Series.SeriesType.Home)
				.Sum(divisionSeries => divisionSeries.Games.Count());

			var awayGames = series.DivisionSeries
				.Where(s => s.Seriestype == Series.SeriesType.Away)
				.Sum(divisionSeries => divisionSeries.Games.Count());

			Assert.IsTrue(homeGames == 38 && awayGames == 38);
		}

		[TestMethod]
		public void IsDivision()
		{
			var division = BaseballScheduleHelper.GetRandomDivision();
			Assert.IsTrue(division.GetType().IsEnum);
		}

		[TestMethod]
		public void GetOpponents()
		{
			var startDivision = BaseballScheduleHelper.GetRandomDivision();
			var teams = BaseballScheduleHelper.GetLeagueTeamsByDivision(League.Circuit.NL, startDivision)
				.ToList();
			var team = BaseballScheduleHelper.GetRandomTeamFromList(teams);
			var opponents = BaseballScheduleHelper.GetDivisionOpponents(team, teams);
			Assert.IsTrue(opponents.All(t => !t.Equals(team)));
		}

		[TestMethod]
		public void GetDivisionTeams()
		{
			var division = BaseballScheduleHelper.GetRandomDivision();
			var teams = BaseballScheduleHelper.GetLeagueTeamsByDivision(League.Circuit.NL, division)
				.ToList();
			var team = BaseballScheduleHelper.GetRandomTeamFromList(teams);
			var opponents = BaseballScheduleHelper.GetDivisionOpponents(team, teams).ToList();
			Assert.IsTrue(
				teams.Count == 5
				&& team.Division == division
				&& teams.Count - opponents.Count == 1
				&& opponents.All(t => !t.Equals(team)));
		}

		[TestMethod]
		public void ScheduleDivisionTeams()
		{
			var scheduledSeries = new SeriesData();
			var startDivision = BaseballScheduleHelper.GetRandomDivision();
			var teams = BaseballScheduleHelper.GetLeagueTeamsByDivision(League.Circuit.NL, startDivision);
			var team = BaseballScheduleHelper.GetRandomTeamFromList(teams);
			var opponents = BaseballScheduleHelper.GetDivisionOpponents(team, teams);

			var scheduledGames = ScheduleGenerator.ScheduleDivisionSeries(scheduledSeries,team,teams,opponents);
			var awayGames = from t in scheduledGames.GamesInSchedule
				where t.AwayTeam == team
				group t by t.AwayTeam
				into a
				select a.Count();

			var homeGames = from t in scheduledGames.GamesInSchedule
				where t.HomeTeam == team
				group t by t.HomeTeam
				into h
				select h.Count();

			var opponentGamesAway = from t in scheduledGames.GamesInSchedule
				where t.AwayTeam == team
				group t by t.HomeTeam
				into a
				select a.Count();

			var opponentGamesHome = from t in scheduledGames.GamesInSchedule
				where t.HomeTeam == team
				group t by t.AwayTeam
				into a
				select a.Count();

			//TODO: Assert scheduled team has played each opponent 19 times
			Assert.IsTrue(awayGames.First() == 38 && homeGames.First() == 38); //Scheduled team should have 38 division home games and 38 division away games
			Assert.IsTrue(scheduledGames.GamesInSchedule.Count == 76); //Total division games scheduled for team should be 76
		}
	}
}

