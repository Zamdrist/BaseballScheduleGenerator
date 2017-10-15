using System.Collections.Generic;

namespace BaseBallSchedule.Core
{
	public class Series
	{
		public List<Game> DivisionSeries { get; set; } = new List<Game>();

		public Series()
		{
			this.DivisionSeries.Add(new Game());
			this.DivisionSeries.Add(new Game());
			this.DivisionSeries.Add(new Game());

		}
	}
}
