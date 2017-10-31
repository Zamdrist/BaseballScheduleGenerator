using System;

namespace BaseballSchedule.Core.Data
{
#if DEBUG
	[Serializable]
#endif
	public class League
	{
		public enum Circuit
		{
			// ReSharper disable once InconsistentNaming
			NL = 0,
			// ReSharper disable once InconsistentNaming
			AL = 1
		}

		public enum Division
		{
			East = 0,
			Central = 1,
			West = 2
		}
	}
}
