using System;

namespace BaseBallSchedule.Core
{

#if DEBUG
	[Serializable]
#endif

	public class Game
    {
        public string AwayTeam { get; set; }

	    public string HomeTeam { get; set; }

		public DateTime GameDate { get; set; }
    }
}
