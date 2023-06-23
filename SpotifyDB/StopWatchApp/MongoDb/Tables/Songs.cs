using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDb.Tables
{
	public class Songs
	{
		[BsonId]
		public Guid UserId { get; set; }
		public string Title { get; set; }
		public TimeSpan Duration { get; set; }
		public DateTime ReleaseDate { get; set; }
		public string Genre { get; set; }
		[BsonId]
		public Guid ArtistId { get; set; }
	}
}
