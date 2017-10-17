using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseBallSchedule.Core
{
	public class ScheduleGeneratorHelper
	{
		// ReSharper disable once InconsistentNaming
		public readonly List<Team> NLTeams;

		public ScheduleGeneratorHelper()
		{
			this.NLTeams = new List<Team>
			{
				new Team {LeagueId = 0, DivisionId = 0, Name = "ATL", League = League.Circuit.NL, Division = League.Division.East},
				new Team {LeagueId = 1, DivisionId = 1, Name = "MIA", League = League.Circuit.NL, Division = League.Division.East},
				new Team {LeagueId = 2, DivisionId = 2, Name = "NYM", League = League.Circuit.NL, Division = League.Division.East},
				new Team {LeagueId = 3, DivisionId = 3, Name = "PHI", League = League.Circuit.NL, Division = League.Division.East},
				new Team {LeagueId = 4, DivisionId = 4, Name = "WSN", League = League.Circuit.NL, Division = League.Division.East},
				new Team {LeagueId = 5, DivisionId = 0, Name = "CHI", League = League.Circuit.NL, Division = League.Division.Central},
				new Team {LeagueId = 6, DivisionId = 1, Name = "CIN", League = League.Circuit.NL, Division = League.Division.Central},
				new Team {LeagueId = 7, DivisionId = 2, Name = "MIL", League = League.Circuit.NL, Division = League.Division.Central},
				new Team {LeagueId = 8, DivisionId = 3, Name = "PIT", League = League.Circuit.NL, Division = League.Division.Central},
				new Team {LeagueId = 9, DivisionId = 4, Name = "STL", League = League.Circuit.NL, Division = League.Division.Central},
				new Team {LeagueId = 10, DivisionId = 0, Name = "ARI", League = League.Circuit.NL, Division = League.Division.West},
				new Team {LeagueId = 11, DivisionId = 1, Name = "COL", League = League.Circuit.NL, Division = League.Division.West},
				new Team {LeagueId = 12, DivisionId = 2, Name = "LAD", League = League.Circuit.NL, Division = League.Division.West},
				new Team {LeagueId = 13, DivisionId = 3, Name = "SDP", League = League.Circuit.NL, Division = League.Division.West},
				new Team {LeagueId = 14, DivisionId = 4, Name = "SFG", League = League.Circuit.NL, Division = League.Division.West}

			};
		}

		public Team GetTeamByName(string teamName)
		{
			return this.NLTeams.SingleOrDefault(t =>
				t.Name.Equals(teamName, StringComparison.OrdinalIgnoreCase));
		}

		public Team GetTeamByLeaugueId(int leagueId)
		{
			return this.NLTeams.SingleOrDefault(t => t.LeagueId.Equals(leagueId));
		}

		public Team GetRandomLeagueTeam(League.Circuit league, List<Team> nlTeams)
		{
			var r = new Random();
			var id = r.Next(0, nlTeams.Count);
			return nlTeams[id];
		}

		public Team GetRandomLeagueTeamByDivision(League.Circuit league, League.Division division, List<Team> nlTeams)
		{
			var r = new Random();
			var id = r.Next(0, nlTeams.FindAll(t => t.Division == division).Count);
			return nlTeams[id];
		}

	}
}
