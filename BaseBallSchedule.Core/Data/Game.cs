using System;

namespace BaseballSchedule.Core.Data
{

#if DEBUG
	[Serializable]
#endif

	public class Game
    {
        public String AwayTeam { get; set; }

	    public String HomeTeam { get; set; }

		public DateTime GameDate { get; set; }
    }
}
