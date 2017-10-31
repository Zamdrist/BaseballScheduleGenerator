using System.Collections.Generic;

namespace BaseballSchedule.Core.Data
{
    public class Schedule
    {
	    public Team ScheduledTeam;
        public ICollection<Game> GamesInSchedule { get; set; } = new List<Game>();
    }
}
