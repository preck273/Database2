using System;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Linq;

namespace ADO.NET
{
	class Program
	{
		//main for ADO.NET
		static void Main(string[] args)
		{
			CRUD crud = new CRUD();

			string connectionString = "Server=(LocalDB)\\MSSQLLocalDB;Initial Catalog=SpotifyDb_New;Integrated Security=True";
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();

				// Set the command timeout to a longer duration (e.g., 200 seconds)
				int commandTimeoutSeconds = 600;
				SqlCommand command = new SqlCommand();
				command.Connection = connection;
				command.CommandTimeout = commandTimeoutSeconds;

				//crud.TimeItTakesToInsertData(connection, 1000000);
				//crud.TimeItTakesToReadData(connection, 1000000);
				//crud.TimeItTakesToUpdateData(connection, 1);
				crud.TimeItTakesToDeleteData(connection, 1000000);


			}
		}
	}
}
