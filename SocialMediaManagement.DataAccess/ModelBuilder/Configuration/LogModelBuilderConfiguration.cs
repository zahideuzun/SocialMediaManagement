using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaManagement.DataAccess.Entities;

namespace SocialMediaManagement.DataAccess.Model.Configuration
{
	public class LogModelConfiguration : EntityTypeConfiguration<Log>
	{
		public LogModelConfiguration()
		{
			HasKey(a => a.LogId);

			Property(a => a.LogDescription)
				.HasMaxLength(50);

			Property(x => x.UserId).IsOptional();

			HasOptional(x => x.User)
				.WithMany(x => x.Logs)
				.HasForeignKey(x => x.UserId);
		}

	}
}

