using EntityFrameWork.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork
{
	class Program
	{


		static void Main(string[] args)
		{
			AppDbContext dbContext = new AppDbContext();
			CRUD crud = new CRUD();
			crud.TimeItTakesToInsertData(dbContext, 100000, "Pop");
			//crud.TimeItTakesToReadData(dbContext, 1000000);
			//crud.TimeItTakesToUpdateData(dbContext, 100000);
			//crud.TimeItTakesToDeleteData(dbContext, 1000);
		}
	}
}
