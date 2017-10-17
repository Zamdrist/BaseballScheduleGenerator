using System.Collections.Generic;

namespace BaseBallSchedule.Core
{
	public class Series
	{
		public readonly int[,] DivisionHomeGames =
		{
			{2, 3, 4},
			{3, 3, 3},
			{3, 3, 4},
			{3, 3, 4}
		};

		public readonly int[,] DivisionAwayGames =
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
