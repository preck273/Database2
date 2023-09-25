
using System;

namespace Monogo
{
	class Program
	{
		static void Main(string[] args)
		{
			CRUD CRUD = new CRUD("Spotify");

			//CRUD.TimeItTakesToInsert(1000000);
			//CRUD.TimeItTakesToRead(1000000);
			//CRUD.TimeItTakesToUpdate(1000000);
			CRUD.TimeItTakesToInsert(10);

			Console.WriteLine("Successful");
			Console.ReadLine();
		}
	}
}
