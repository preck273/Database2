using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork.DataModel
{
	public class UserLikes
	{
		[Key]
		public int UserLikesId { get; set; }

		[ForeignKey("UserId")]
		public int UserId { get; set; }

		[ForeignKey("SongId")]
		public int SongId { get; set; }

		public User User { get; set; } 

		public Song Song { get; set; }
	}

}
