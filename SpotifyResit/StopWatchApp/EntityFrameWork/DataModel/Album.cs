using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork.DataModel
{
	public class Album
	{
		[Key]
		public int AlbumId { get; set; }

		public string Title { get; set; }

		public DateTime ReleaseDate { get; set; }

		[ForeignKey("SongId")]
		public int SongId { get; set; }

		[ForeignKey("ArtistId")]
		public int ArtistId { get; set; }

		public Artist Artist { get; set; }
	}
}
