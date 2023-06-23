using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
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
