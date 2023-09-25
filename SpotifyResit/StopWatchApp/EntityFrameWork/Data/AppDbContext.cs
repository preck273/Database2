using EntityFrameWork.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork.Data
{
	public class AppDbContext : DbContext
	{

		public DbSet<User> Users { get; set; }
		public DbSet<Artist> Artists { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Song> Songs { get; set; }
		public DbSet<Album> Albums { get; set; }
		public DbSet<Playlist> Playlists { get; set; }
		public DbSet<PlaylistSong> PlaylistSongs { get; set; }
		public DbSet<UserLikes> UserLikes { get; set; }
		public DbSet<SongGenre> SongGenres { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Initial Catalog=SpotifyDatabaseEResit;Integrated Security=True");
		}
	}


}
