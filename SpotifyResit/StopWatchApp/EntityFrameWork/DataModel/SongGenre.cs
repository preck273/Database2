using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Conventions.Inspections;

namespace EntityFrameWork.DataModel
{
	public class SongGenre
	{
		[Key]
		public int SongGenreId { get; set; }

		
		[ForeignKey("SongId")]
		public int SongId { get; set; }

		[ForeignKey("GenreId")]
		public int GenreId { get; set; }

		public Song Song { get; set; } // Navigation property to Song

		public Genre Genre { get; set; }
	}
}
