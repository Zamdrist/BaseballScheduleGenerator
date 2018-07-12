using System.Collections.Generic;
using System.Linq;
using BaseballSchedule.Core.Data;

namespace BaseballSchedule.Core
{
	public static class ScheduleGenerator
	{
		private static readonly Schedule Schedule = new Schedule();

		public static void ScheduleSeries(Team team, Team opponent, Series series)
		{
			foreach (var game in series.Games)
			{
				// ReSharper disable once SwitchStatementMissingSomeCases
				switch (series.Seriestype)
				{
					case Series.SeriesType.Home:
						game.HomeTeam = team.Name;
						game.AwayTeam = opponent.Name;
						break;
					case Series.SeriesType.Away:
						game.HomeTeam = opponent.Name;
						game.AwayTeam = team.Name;
						break;
				}
				ScheduleGenerator.Schedule.GamesInSchedule.Add(game);
			}
		}

		public static Schedule ScheduleDivisionSeries()
		{
			var divisionSeries = new SeriesData();
			var startDivision = BaseballScheduleHelper.GetRandomDivision();
			var teams = BaseballScheduleHelper.GetLeagueTeamsByDivision(League.Circuit.NL, startDivision);
			var team = BaseballScheduleHelper.GetRandomTeamFromList(teams);
			var opponents = BaseballScheduleHelper.GetDivisionOpponents(team, teams);

			foreach (var series in divisionSeries.DivisionSeries)
			{
				var opponent = BaseballScheduleHelper.GetRandomTeamFromList(opponents);
				ScheduleGenerator.ScheduleSeries(team, opponent, series);
				opponents.Remove(opponent);
				if (!opponents.Any())
				{
					opponents = BaseballScheduleHelper.GetDivisionOpponents(team, teams);
				}

			}

			return ScheduleGenerator.Schedule;
		}
	}
}
