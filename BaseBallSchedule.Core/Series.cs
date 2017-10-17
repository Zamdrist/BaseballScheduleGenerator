using System.Collections.Generic;

namespace BaseBallSchedule.Core
{
	public class Series
	{
		public const int NumberOfDivisionHomeGames = 38;
		public readonly int[,] HomeSeries =
		{
			{2, 3, 4},
			{3, 3, 3},
			{3, 3, 4},
			{3, 3, 4}
		};

		public const int NumberOfDivisionAwayGames = 38;
		public readonly int[,] AwaySeries =
		{
			{3, 3, 4},
			{3, 3, 4},
			{2, 3, 4},
			{3, 3, 3}
		};

		public const int DivisionSeriesGames = 3;

		public List<Game> DivisionSeries { get; set; } = new List<Game>();
	}
}
