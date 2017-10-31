using System.Collections.Generic;

namespace BaseballSchedule.Core.Data
{
	public class TeamData
	{
		public readonly IEnumerable<Team> Teams;

		public TeamData()
		{
			this.Teams = new List<Team>
			{
				new Team
				{
					Name = "ATL",
					League = League.Circuit.NL,
					Division = League.Division.East
				},
				new Team
				{
					Name = "MIA",
					League = League.Circuit.NL,
					Division = League.Division.East
				},
				new Team
				{
					Name = "NYM",
					League = League.Circuit.NL,
					Division = League.Division.East
				},
				new Team
				{
					Name = "PHI",
					League = League.Circuit.NL,
					Division = League.Division.East
				},
				new Team
				{
					Name = "WSN",
					League = League.Circuit.NL,
					Division = League.Division.East
				},
				new Team
				{
					Name = "CHI",
					League = League.Circuit.NL,
					Division = League.Division.Central
				},
				new Team
				{
					Name = "CIN",
					League = League.Circuit.NL,
					Division = League.Division.Central
				},
				new Team
				{
					Name = "MIL",
					League = League.Circuit.NL,
					Division = League.Division.Central
				},
				new Team
				{
					Name = "PIT",
					League = League.Circuit.NL,
					Division = League.Division.Central
				},
				new Team
				{
					Name = "STL",
					League = League.Circuit.NL,
					Division = League.Division.Central
				},
				new Team
				{
					Name = "ARI",
					League = League.Circuit.NL,
					Division = League.Division.West
				},
				new Team
				{
					Name = "COL",
					League = League.Circuit.NL,
					Division = League.Division.West
				},
				new Team
				{
					Name = "LAD",
					League = League.Circuit.NL,
					Division = League.Division.West
				},
				new Team
				{
					Name = "SDP",
					League = League.Circuit.NL,
					Division = League.Division.West
				},
				new Team
				{
					Name = "SFG",
					League = League.Circuit.NL,
					Division = League.Division.West
				}
			};
		}
	}
}
