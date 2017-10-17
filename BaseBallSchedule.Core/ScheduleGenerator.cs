using System.Collections.Generic;

namespace BaseBallSchedule.Core
{
    public class ScheduleGenerator
    {
        public List<Team> Teams { get; set; }

        public Schedule GenerateSchedule()
        {
            var schedule = new Schedule();
	        var gameDate = schedule.OpeningDay;

            for (var count = 0; count < Schedule.GamesPerTeam; count++)
            {
	            for (var matchups = 0; matchups < Schedule.Matchups; matchups++)
	            {
		            schedule.GamesInSchedule.Add(
			            new Game
			            {
				            AwayTeam = this.Teams[0].Name,
				            HomeTeam = this.Teams[1].Name,
				            GameDate = gameDate
			            });
	            }
	            gameDate = gameDate.AddDays(1);
            }
            return schedule;
        }
    }
}
