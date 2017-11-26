using System.Collections.Generic;
using System.Linq;
using BaseballSchedule.Core.Data;

namespace BaseballSchedule.Core
{
	public static class ScheduleGenerator
	{
		private static readonly Schedule Schedule = new Schedule();

		private static void ScheduleSeries(Team team, Team opponent, Series series)
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

		public static Schedule ScheduleDivisionSeries(Team team, List<Team> teams, int scheduleCountdown)
		{
			var seriesToSchedule = BaseballScheduleHelper.GetDivisionSeriesData();
			var maxSeriesId = BaseballScheduleHelper.MaxSeriesId(seriesToSchedule);
			var maxMatchupId = BaseballScheduleHelper.MaxMatchupId(seriesToSchedule);
			var opponents = BaseballScheduleHelper.GetDivisionOpponents(team, teams).ToList();
			var seriesCounter = 0;

			foreach (var opponent in opponents)
			{
				var quarterSeries = BaseballScheduleHelper.GetQuarterSeries(
					seriesToSchedule,
					seriesCounter,
					scheduleCountdown,
					maxMatchupId);

				foreach (var matchup in quarterSeries)
				{
					ScheduleGenerator.ScheduleSeries(team, opponent, matchup);

				}

				seriesCounter++;
				if (seriesCounter == maxSeriesId + 1)
				{
					break;
				}
			}
			return ScheduleGenerator.Schedule;
		}
	}
}
