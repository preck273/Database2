using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameWork.DataModel
{
	[Table("User")]
	public class User
	{
		[Key]
		public int UserId { get; set; }

		[Required]
		public string Username { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }

		public DateTime RegisteredDate { get; set; }
	}
}
