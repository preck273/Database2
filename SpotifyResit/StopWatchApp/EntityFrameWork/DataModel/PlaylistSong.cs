using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork.DataModel
{
	public class PlaylistSong
	{
		[Key]
		public int PlaylistSongId { get; set; }

		public int Position { get; set; }

		[ForeignKey("PlaylistId")]
		public int PlaylistId { get; set; }

		[ForeignKey("SongId")]
		public int SongId { get; set; }

		public Playlist Playlist { get; set; } 

		public Song Song { get; set; }

	}

}
