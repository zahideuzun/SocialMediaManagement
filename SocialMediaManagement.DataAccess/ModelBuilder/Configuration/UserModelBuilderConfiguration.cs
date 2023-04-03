using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaManagement.DataAccess.Entities;

namespace SocialMediaManagement.DataAccess.Model.Configuration
{
	public class UserModelConfiguration : EntityTypeConfiguration<User>
	{
		public UserModelConfiguration()
		{
			HasKey(c => c.UserId);

			Property(c => c.Name)
				.IsRequired()
				.HasMaxLength(60);

			Property(c => c.Surname)
				.IsRequired()
				.HasMaxLength(60);

			Property(c => c.Email)
				.IsRequired()
				.HasMaxLength(250);

			Property(c => c.Phone)
				.IsRequired()
				.HasMaxLength(11);

			Property(c => c.Password)
				.IsRequired()
				.HasMaxLength(20);

			HasMany(u => u.UserSocialMediaAccounts)
				.WithRequired(usm => usm.User)
				.HasForeignKey(usm => usm.UserId);

		}
	}
}
