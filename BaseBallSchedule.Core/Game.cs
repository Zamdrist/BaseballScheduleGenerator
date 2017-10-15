using System;

namespace BaseBallSchedule.Core
{
    public class Game
    {
        public Team HomeTeam { get; set; }

        public Team AwayTeam { get; set; }

        public DateTime GameDate { get; set; }
    }
}
