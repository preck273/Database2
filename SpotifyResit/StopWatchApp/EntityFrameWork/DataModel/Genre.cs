using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork.DataModel
{
	public class Genre
	{
		[Key]
		public int GenreId { get; set; }

		[Required]
		public string GenreName { get; set; }

		// Navigation property to represent the relationship with songs
		public List<Song> Songs { get; set; }
	}
}
