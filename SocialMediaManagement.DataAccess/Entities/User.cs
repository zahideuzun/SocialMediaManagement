using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaManagement.DataAccess.Entities
{
	public class User
	{
		public int UserId { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Password { get; set; }
		public bool IsEmailConfirm { get; set; }

		public ICollection<UserSocialMedia> UserSocialMediaAccounts { get; set; }
		public ICollection<Log> Logs { get; set; }

	}
}
