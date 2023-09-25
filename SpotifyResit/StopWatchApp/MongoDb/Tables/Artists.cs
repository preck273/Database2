using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDb.Tables
{
	public class Artists
	{
		[BsonId]
		public Guid ArtistId { get; set; }
		public string Name { get; set; }
		public string Biography { get; set; }
		public string Origin { get; set; }
	}
}
