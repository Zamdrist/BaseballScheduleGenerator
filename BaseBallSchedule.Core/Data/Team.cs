using System;

namespace BaseballSchedule.Core.Data
{
#if DEBUG
	[Serializable]
#endif
	public class Team
	{
		public League.Circuit League { get; set; }
        public League.Division Division { get; set; }
        public string Name { get; set; }
    }
}
