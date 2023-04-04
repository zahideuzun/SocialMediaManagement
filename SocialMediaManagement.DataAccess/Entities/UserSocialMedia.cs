using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaManagement.DataAccess.Entities
{
	public class UserSocialMedia
	{
		public int UserSocialMediaId { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Username { get; set; }
		public int UserId { get; set; }
		public User User { get; set; }
		public int SocialMediaId { get; set; }
		public SocialMedia SocialMedia { get; set; }
	}
}
