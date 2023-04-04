using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaManagement.DataAccess.Entities;

namespace SocialMediaManagement.DataAccess.Model.Configuration
{
	public class LogTypeModelConfiguration : EntityTypeConfiguration<LogType>
	{
		public LogTypeModelConfiguration()
		{
			HasKey(lt => lt.LogTypeId);
			Property(lt => lt.LogTypeDescription)
				.HasMaxLength(100);

			HasMany(lt => lt.Logs)
				.WithRequired(l => l.LogType)
				.HasForeignKey(l => l.LogTypeId);

			
		}

	}
}

