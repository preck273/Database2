using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ADO.NET
{
	public class CRUD
	{
		private Stopwatch stopwatch = new Stopwatch();

		public void TimeItTakesToInsertData(SqlConnection conn, int numberOfRows)
		{
			stopwatch.Start();
			for (int i = 1; i <= numberOfRows; i++)
			{
				string name = "User " + i;  // Generate a unique name for each user
				string biography = "I love singing " + i; 
				string origin = "USA " + i;

				string query = "INSERT INTO Artists (Name, Biography, Origin) VALUES (@name, @biography, @origin)";
				SqlCommand command = new SqlCommand(query, conn);
				command.Parameters.AddWithValue("@name", name);
				command.Parameters.AddWithValue("@biography", biography);
				command.Parameters.AddWithValue("@origin", origin);

				try
				{
					int affectedRows = command.ExecuteNonQuery();
					Console.WriteLine("{0} rows have been added", affectedRows);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			stopwatch.Stop();
			Console.WriteLine("Elapsed time: " + stopwatch.Elapsed);
		}


		// Read method
		public void TimeItTakesToReadData(SqlConnection conn, int numberOfRows)
		{
			stopwatch.Start();
			string query = "SELECT TOP (@numberOfRows) * FROM Artists";
			SqlCommand command = new SqlCommand(query, conn);
			command.Parameters.AddWithValue("@numberOfRows", numberOfRows);

			try
			{
				SqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					Console.WriteLine("{0}\t{1}\t{2}", reader[0], reader[1], reader[2]);
				}
				reader.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			stopwatch.Stop();
			Console.WriteLine("Elapsed time: " + stopwatch.Elapsed);
		}

		// Update method
		public void TimeItTakesToUpdateData(SqlConnection conn, int numberOfRows)
		{
			stopwatch.Start();
			for (int i = 1; i <= numberOfRows; i++)
			{
				string name = "User " + i;  // Generate a unique name for each user
				string biography = "I love singing " + i;
				string origin = "USA " + i;

				string query = "UPDATE Artists SET Biography = @biography, Origin = @origin WHERE Name = @name";
				SqlCommand command = new SqlCommand(query, conn);
				command.Parameters.AddWithValue("@biography", biography);
				command.Parameters.AddWithValue("@origin", origin);
				command.Parameters.AddWithValue("@name", name);

				try
				{
					int affectedRows = command.ExecuteNonQuery();
					Console.WriteLine("{0} rows have been updated", affectedRows);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			stopwatch.Stop();
			Console.WriteLine("Elapsed time: " + stopwatch.Elapsed);
		}


		// Delete method
		public void TimeItTakesToDeleteData(SqlConnection conn, int numberOfRows)
		{
			stopwatch.Start();
			string query = "DELETE TOP (@numberOfRows) FROM Artists";
			SqlCommand command = new SqlCommand(query, conn);
			command.Parameters.AddWithValue("@numberOfRows", numberOfRows);

			try
			{
				int affectedRows = command.ExecuteNonQuery();
				Console.WriteLine("{0} rows have been deleted", affectedRows);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			stopwatch.Stop();
			Console.WriteLine("Elapsed time: " + stopwatch.Elapsed);
		}
	}
}
