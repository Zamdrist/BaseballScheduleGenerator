using System;

namespace BaseballSchedule.Core.Data
{

#if DEBUG
	[Serializable]
#endif

	public class Game
    {
        public Team AwayTeam { get; set; }

	    public Team HomeTeam { get; set; }

		public DateTime GameDate { get; set; }
    }
}
