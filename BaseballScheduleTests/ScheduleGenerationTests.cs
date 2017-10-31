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
	/// <summary>
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
			var teams = BaseballScheduleHelper.GetLeagueTeamsByDivision(League.Circuit.NL, startDivision).ToList();
			var team = BaseballScheduleHelper.GetRandomTeamFromList(teams);
			var opponents = BaseballScheduleHelper.GetDivisionOpponents(team, teams);
			Assert.IsTrue(opponents.All(t => !t.Equals(team)));
		}

		[TestMethod]
		public void GetDivisionTeams()
		{
			var division = BaseballScheduleHelper.GetRandomDivision();
			var teams = BaseballScheduleHelper.GetLeagueTeamsByDivision(League.Circuit.NL, division).ToList();
			var team = BaseballScheduleHelper.GetRandomTeamFromList(teams);
			var opponents = BaseballScheduleHelper.GetDivisionOpponents(team, teams).ToList();
			Assert.IsTrue(
				teams.Count == 5
				&& team.Division == division
				&& teams.Count - opponents.Count == 1
				&& opponents.All(t => !t.Equals(team)));
		}

		[TestMethod]
		public void GetTeamSchedule()
		{
			var seriesData = new SeriesData();
			var random = new Random();
			var maxSeriesId = seriesData.DivisionSeries.Max(s => s.SeriesId);
			var seriesId = random.Next(0, maxSeriesId);
			var series = seriesData.DivisionSeries.Where(s => s.SeriesId == seriesId).ToList();

			Assert.IsTrue(series.Count(h => h.Seriestype == Series.SeriesType.Home) == 3);
			Assert.IsTrue(series.Count(h => h.Seriestype == Series.SeriesType.Away) == 3);
		}

		[TestMethod]
		public void RandomSeriesMatchupCount()
		{
			var seriesData = new SeriesData();
			var series = BaseballScheduleHelper.GetRandomSeries(seriesData.DivisionSeries.ToList());
			Assert.IsTrue(
				series.Count(h => h.Seriestype == Series.SeriesType.Home)
				+ series.Count(a => a.Seriestype == Series.SeriesType.Away)
				== 6);
		}

		[TestMethod]
		public void ScheduleSeries()
		{
			var division = BaseballScheduleHelper.GetRandomDivision();
			var teams = BaseballScheduleHelper.GetLeagueTeamsByDivision(League.Circuit.NL, division).ToList();
			var team = BaseballScheduleHelper.GetRandomTeamFromList(teams);
			var opponents = BaseballScheduleHelper.GetDivisionOpponents(team, teams).ToList();
			var schedule = ScheduleGenerator.ScheduleSeries(team, opponents);
			Assert.IsTrue(schedule.GamesInSchedule.Count == 19);
		}
	}
}

