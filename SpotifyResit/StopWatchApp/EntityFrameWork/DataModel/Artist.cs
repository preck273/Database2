using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork.DataModel
{
	public class Artist
	{
		[Key]
		public int ArtistId { get; set; }

		[Required]
		public string Name { get; set; }

		public string Biography { get; set; }

		public string Origin { get; set; }

		public List<Song> Songs { get; set; }
	}
}
