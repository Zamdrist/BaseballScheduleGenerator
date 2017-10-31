using System;
using System.Collections.Generic;
using System.Linq;
using BaseballSchedule.Core.Data;

namespace BaseballSchedule.Core
{
	public static class BaseballScheduleHelper
	{
		public static IEnumerable<Team> GetLeagueTeamsByDivision(
			League.Circuit league,
			League.Division division)
		{
			var teamData = new TeamData();
			return teamData.Teams.Where(l => l.League == league && l.Division == division).ToList();
		}

		public static Team GetRandomTeamFromList(IList<Team> teams)
		{
			var random = new Random();
			var id = random.Next(0, teams.Count);
			return teams.ElementAt(id);
		}

		public static League.Division GetRandomDivision()
		{
			var random = new Random();
			var division = random.Next(0, Enum.GetValues(typeof(League.Division)).GetUpperBound(0));
			return (League.Division)division;
		}

		public static IEnumerable<Team> GetDivisionOpponents(Team team, IEnumerable<Team> teams)
		{
			var opponents = teams.Where(t => !t.Equals(team) && t.Division == team.Division);
			return opponents;
		}

		private static int MaxSeriesId(IEnumerable<Series> series)
		{
			return series.Max(s => s.SeriesId);

		}

		public static IEnumerable<Series> GetRandomSeries(IList<Series> series)
		{
			var maxSeriesId = BaseballScheduleHelper.MaxSeriesId(series);
			var random = new Random();
			var randomSeriesId = random.Next(0, maxSeriesId);
			return series.Where(s => s.SeriesId == randomSeriesId);
		}
	}
}