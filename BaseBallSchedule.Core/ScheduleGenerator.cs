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
						game.HomeTeam = team;
						game.AwayTeam = opponent;
						break;
					case Series.SeriesType.Away:
						game.HomeTeam = opponent;
						game.AwayTeam = team;
						break;
				}
				ScheduleGenerator.Schedule.GamesInSchedule.Add(game);
			}
		}

		public static Schedule ScheduleDivisionSeries(SeriesData scheduledSeries, Team team, IList<Team> teams, IList<Team> opponents)
		{
			foreach (var series in scheduledSeries.DivisionSeries)
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
