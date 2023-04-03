using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaManagement.DataAccess.Entities
{
	public class SocialMedia
	{
		public int SocialMediaId { get; set; }
		public string Name { get; set; }

		public ICollection<UserSocialMedia> UserSocialMediaAccounts { get; set; }
	}
}
