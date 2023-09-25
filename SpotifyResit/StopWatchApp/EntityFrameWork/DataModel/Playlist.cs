using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork.DataModel
{
	public class Playlist
	{
		[Key]
		public int PlaylistId { get; set; }

		public string Title { get; set; }

		public DateTime CreationDate { get; set; }

		[ForeignKey("UserId")]
		public int UserId { get; set; }

		public List<PlaylistSong> PlaylistSongs { get; set; }

		public User User { get; set; }
	}
}
