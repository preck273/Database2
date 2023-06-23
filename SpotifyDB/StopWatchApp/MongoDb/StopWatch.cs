using System;
using System.Diagnostics;

namespace MongoDB
{
	public class StopWatch
	{
		private Stopwatch stopwatch = new Stopwatch();

		public void StartTime()
		{
			stopwatch.Start();
		}

		public void EndTime()
		{
			stopwatch.Stop();
			Console.WriteLine("Time taken: {0}", stopwatch.Elapsed);
		}
	}
}
