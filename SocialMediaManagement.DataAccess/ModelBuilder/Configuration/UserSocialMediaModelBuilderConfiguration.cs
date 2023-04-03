using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaManagement.DataAccess.Entities;

namespace SocialMediaManagement.DataAccess.Model.Configuration
{
	public class UserSocialMediaModelConfiguration : EntityTypeConfiguration<UserSocialMedia>
	{
		public UserSocialMediaModelConfiguration()
		{
			HasKey(x => x.UserSocialMediaId);
			Property(x => x.Password).HasMaxLength(20);
			Property(x => x.Email).HasMaxLength(250);
		}
		
	}
}
