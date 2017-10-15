
namespace BaseBallSchedule.Core
{
    public class Team
    {
		public int LeagueId { get; set; }
	    public int DivisionId { get; set; }
		public League.Circuit League { get; set; }
        public League.Division Division { get; set; }
        public string Name { get; set; }
    }
}
