using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork.DataModel
{
	public class Song
	{
		[Key]
		public int SongId { get; set; }

		public string Title { get; set; }

		public TimeSpan Duration { get; set; }

		public DateTime ReleaseDate { get; set; }

		[ForeignKey("ArtistId")]
		public int ArtistId { get; set; } //FK

		[ForeignKey("GenreId")]
		public int GenreId { get; set; } //FK

		public Artist Artist { get; set; } 

		public Genre Genre { get; set; }

		public List<UserLikes> UserLikes { get; set; }
	}
}
