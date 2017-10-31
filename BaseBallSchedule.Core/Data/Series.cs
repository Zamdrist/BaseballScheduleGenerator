using System;
using System.Collections.Generic;

namespace BaseballSchedule.Core.Data
{

#if DEBUG
	[Serializable]
#endif

	public class Series
	{
		public int SeriesId;
		public int MatchupId;
		public enum SeriesType
		{
			Home = 0,
			Away = 1
		}
		public IEnumerable<Game> Games { get; set; }
		public SeriesType Seriestype;

	}
}
