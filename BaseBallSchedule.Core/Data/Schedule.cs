using System.Collections.Generic;

namespace BaseballSchedule.Core.Data
{
    public class Schedule
    {
        public ICollection<Game> GamesInSchedule { get; set; } = new List<Game>();
    }
}
