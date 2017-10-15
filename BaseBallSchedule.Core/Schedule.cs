using System;
using System.Collections.Generic;

namespace BaseBallSchedule.Core
{
    public class Schedule
    {

	    public const int GamesPerTeam = 162;
	    public const int Matchups = 15;
	    public DateTime OpeningDay = new DateTime(2018, 4, 2);
        public List<Game> GamesInSchedule { get; set; } = new List<Game>();
    }
}
