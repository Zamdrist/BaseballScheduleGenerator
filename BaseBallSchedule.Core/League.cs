
namespace BaseBallSchedule.Core
{
	public class League
	{
		public const int TeamsInLeague = 15;
		public const int TeamsInDivision = 5;
		public static int OpponentsInDivision = League.TeamsInDivision - 1;

		public enum Division
		{
			East = 0,
			Central = 1,
			West = 2
		}

		public enum Circuit
		{
			// ReSharper disable once InconsistentNaming
			NL = 0,
			// ReSharper disable once InconsistentNaming
			AL = 1
		}
	}
}
