using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaManagement.DataAccess.Entities;
using SocialMediaManagement.DataAccess.Model.Configuration;

namespace SocialMediaManagement.DataAccess.Context
{
	public class SocialMediaContext : DbContext
	{
		public SocialMediaContext() : base("SocialMediaDB")
		{
			Configuration.LazyLoadingEnabled = false;
		}

		protected override void OnModelCreating(DbModelBuilder model)
		{
			model.Configurations.Add(new LogModelConfiguration());
			model.Configurations.Add(new LogTypeModelConfiguration());
			model.Configurations.Add(new SocialMediaModelConfiguration());
			model.Configurations.Add(new UserModelConfiguration());
			model.Configurations.Add(new UserSocialMediaModelConfiguration());
		}

		public DbSet<Log> Logs { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<SocialMedia> SocialMedias { get; set; }
		public DbSet<UserSocialMedia> UserSocialMedias { get; set; }
		public DbSet<LogType> LogTypes { get; set; }

	}
}
