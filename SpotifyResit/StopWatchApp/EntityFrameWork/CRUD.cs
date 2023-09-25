using EntityFrameWork.Data;
using EntityFrameWork.DataModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork
{
	public class CRUD
	{
		Stopwatch stopwatch = new Stopwatch();

		public void TimeItTakesToInsertData(AppDbContext dbContext, int numberOfRows, string genreName)
		{
			stopwatch.Start();
			for (int i = 1; i <= numberOfRows; i++)
			{
				Genre genre = new Genre() { GenreName = genreName };

				try
				{
					dbContext.Genres.Add(genre);
					dbContext.SaveChanges();
					//Console.WriteLine("Inserting " + i + " time\n");
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			stopwatch.Stop();
			Console.WriteLine("Elapsed time: " + stopwatch.Elapsed);
			Console.WriteLine("Inserted " + numberOfRows + " rows successfully");
		}

		public void TimeItTakesToReadData(AppDbContext dbContext, int numberOfRows)
		{
			stopwatch.Start();
			var genres = dbContext.Genres.ToList();
			for (int i = 0; i < genres.Count && i < numberOfRows; i++)
			{
				//
			}
			stopwatch.Stop();
			Console.WriteLine("Elapsed time: " + stopwatch.Elapsed);
			Console.WriteLine("Read " + numberOfRows + " rows successfully");
		}

		public void TimeItTakesToUpdateData(AppDbContext dbContext, int numberOfRows)
		{
			stopwatch.Start();
			for (int i = 1; i <= numberOfRows; i++)
			{
				// Data to update
				Genre genre = dbContext.Genres.First(g => g.GenreName.Equals("Pop"));

				// Set data to a new one
				genre.GenreName = "Blues";

				dbContext.SaveChanges();
			}
			stopwatch.Stop();
			Console.WriteLine("Updated " + numberOfRows + " rows successfully");
			Console.WriteLine("Elapsed time: " + stopwatch.Elapsed);
		}

		public void TimeItTakesToDeleteData(AppDbContext dbContext, int numberOfRows)
		{
			stopwatch.Start();
			for (int i = 1; i <= numberOfRows; i++)
			{
				Genre genre = dbContext.Genres.First(g => g.GenreName.Equals("Blues"));

				dbContext.Genres.Remove(genre);
				dbContext.SaveChanges();
			}
			stopwatch.Stop();
			Console.WriteLine("Elapsed time: " + stopwatch.Elapsed);
			Console.WriteLine("Deleted " + numberOfRows + " rows successfully");
		}
	}

}
