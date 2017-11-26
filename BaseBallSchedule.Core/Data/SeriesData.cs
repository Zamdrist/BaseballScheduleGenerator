using System.Collections.Generic;

namespace BaseballSchedule.Core.Data
{
	public class SeriesData : Series
	{
		/*
		 In division, all four teams faced have different schedules:
			2 3 4 at home, 3 3 4 on the road
			3 3 3 at home, 3 3 4 on the road
			3 3 4 at home, 2 3 4 on the road
			3 3 4 at home, 3 3 3 on the road
		*/
		public readonly IEnumerable<Series> DivisionSeries;

		public SeriesData()
		{
			this.DivisionSeries = new List<Series>
			{
				new Series {SeriesId = 0, MatchupId = 0, Seriestype = SeriesType.Home, Games = new List<Game> {new Game(), new Game()}},
				new Series {SeriesId = 0, MatchupId = 1, Seriestype = SeriesType.Home, Games = new List<Game> {new Game(), new Game(), new Game()}},
				new Series {SeriesId = 0, MatchupId = 2, Seriestype = SeriesType.Home, Games = new List<Game> {new Game(), new Game(), new Game(), new Game()}},
				new Series {SeriesId = 0, MatchupId = 3, Seriestype = SeriesType.Away, Games = new List<Game> {new Game(), new Game(), new Game()}},
				new Series {SeriesId = 0, MatchupId = 4, Seriestype = SeriesType.Away, Games = new List<Game> {new Game(), new Game(), new Game()}},
				new Series {SeriesId = 0, MatchupId = 5, Seriestype = SeriesType.Away, Games = new List<Game> {new Game(), new Game(), new Game(), new Game()}},
				new Series {SeriesId = 1, MatchupId = 0, Seriestype = SeriesType.Home, Games = new List<Game> {new Game(), new Game(), new Game()}},
				new Series {SeriesId = 1, MatchupId = 1, Seriestype = SeriesType.Home, Games = new List<Game> {new Game(), new Game(), new Game()}},
				new Series {SeriesId = 1, MatchupId = 2, Seriestype = SeriesType.Home, Games = new List<Game> {new Game(), new Game(), new Game()}},
				new Series {SeriesId = 1, MatchupId = 3, Seriestype = SeriesType.Away, Games = new List<Game> {new Game(), new Game(), new Game()}},
				new Series {SeriesId = 1, MatchupId = 4, Seriestype = SeriesType.Away, Games = new List<Game> {new Game(), new Game(), new Game()}},
				new Series {SeriesId = 1, MatchupId = 5, Seriestype = SeriesType.Away, Games = new List<Game> {new Game(), new Game(), new Game(), new Game()}},
				new Series {SeriesId = 2, MatchupId = 0, Seriestype = SeriesType.Home, Games = new List<Game> {new Game(), new Game(), new Game()}},
				new Series {SeriesId = 2, MatchupId = 1, Seriestype = SeriesType.Home, Games = new List<Game> {new Game(), new Game(), new Game()}},
				new Series {SeriesId = 2, MatchupId = 2, Seriestype = SeriesType.Home, Games = new List<Game> {new Game(), new Game(), new Game(), new Game()}},
				new Series {SeriesId = 2, MatchupId = 3, Seriestype = SeriesType.Away, Games = new List<Game> {new Game(), new Game()}},
				new Series {SeriesId = 2, MatchupId = 4, Seriestype = SeriesType.Away, Games = new List<Game> {new Game(), new Game(), new Game()}},
				new Series {SeriesId = 2, MatchupId = 5, Seriestype = SeriesType.Away, Games = new List<Game> {new Game(), new Game(), new Game(), new Game()}},
				new Series {SeriesId = 3, MatchupId = 0, Seriestype = SeriesType.Home, Games = new List<Game> {new Game(), new Game(), new Game()}},
				new Series {SeriesId = 3, MatchupId = 1, Seriestype = SeriesType.Home, Games = new List<Game> {new Game(), new Game(), new Game()}},
				new Series {SeriesId = 3, MatchupId = 2, Seriestype = SeriesType.Home, Games = new List<Game> {new Game(), new Game(), new Game(), new Game()}},
				new Series {SeriesId = 3, MatchupId = 3, Seriestype = SeriesType.Away, Games = new List<Game> {new Game(), new Game(), new Game()}},
				new Series {SeriesId = 3, MatchupId = 4, Seriestype = SeriesType.Away, Games = new List<Game> {new Game(), new Game(), new Game()}},
				new Series {SeriesId = 3, MatchupId = 5, Seriestype = SeriesType.Away, Games = new List<Game> {new Game(), new Game(), new Game()}}
			};
		}
		/*
		 For interdivision play,
			3 teams are 3 at home, 4 on the road
			3 teams are 4 at home, 3 on the road
			4 teams are 3 at home, 3 on the road

		 And for interleage, if it's not the division of the natural rival:
			2 teams are 3 at home
			2 teams are 3 at the road
			1 team is 2 at home, 2 on the road
			2 at home and 2 on the road for the natural rival

		 If it is the natural rival's division:
			1 team is 3 at home
			1 team is 3 on the road
			2 teams are at home, 2 on the road *3 at home and 3 on the road for the natural rival
		*/
	}
}




