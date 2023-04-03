using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaManagement.DataAccess.Context;
using SocialMediaManagement.DataAccess.Entities;

namespace SocialMediaManagement.DataAccess.Model.Configuration
{
	public class SocialMediaModelConfiguration : EntityTypeConfiguration<SocialMedia>
	{
		public SocialMediaModelConfiguration()
		{
			
			HasKey(sm => sm.SocialMediaId);

			Property(sm => sm.Name).IsRequired()
				.HasMaxLength(50);

			HasMany(sm => sm.UserSocialMediaAccounts)
				.WithRequired(usm => usm.SocialMedia)
				.HasForeignKey(usm => usm.SocialMediaId);

		}
	}
}
