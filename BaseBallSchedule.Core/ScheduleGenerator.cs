using System;
using System.Collections.Generic;
using System.Linq;
using BaseballSchedule.Core.Data;

namespace BaseballSchedule.Core
{
	public static class ScheduleGenerator
	{
		private static readonly Schedule Schedule = new Schedule();

		public static Schedule ScheduleSeries(Team team, IList<Team> opponents)
		{
			var seriesData = new SeriesData();
			var seriesToSchedule =
				BaseballScheduleHelper.GetRandomSeries(seriesData.DivisionSeries.ToList()).ToList();
			var seriesCount = 0;

			while (true)
			{
				foreach (var opponent in opponents)
				{
					foreach (var game in seriesToSchedule[seriesCount].Games)
					{
						// ReSharper disable once SwitchStatementMissingSomeCases
						switch (seriesToSchedule[seriesCount].Seriestype)
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
					seriesCount++;
					if (seriesCount > seriesToSchedule.Count - 1)
					{
						return ScheduleGenerator.Schedule;
					}
				}
			}
		}
	}
}
