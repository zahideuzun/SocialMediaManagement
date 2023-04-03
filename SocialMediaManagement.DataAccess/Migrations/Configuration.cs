using System.Collections.Generic;
using SocialMediaManagement.DataAccess.Entities;

namespace SocialMediaManagement.DataAccess.Migrations
{
	using System;
	using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SocialMediaManagement.DataAccess.Context.SocialMediaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SocialMediaManagement.DataAccess.Context.SocialMediaContext context)
        {
			var socialMedias = new List<SocialMedia>
			{
				new SocialMedia { SocialMediaId = 1, Name = "Facebook" },
				new SocialMedia { SocialMediaId = 2, Name = "Twitter" },
				new SocialMedia { SocialMediaId = 3, Name = "Instagram" },
				new SocialMedia { SocialMediaId = 3, Name = "Linkedin" }
			};
			context.SocialMedias.AddOrUpdate(c => c.SocialMediaId, socialMedias.ToArray());
			context.SaveChanges();

			var users = new List<User>
			{
				new User
				{
					UserId = 1,
					Name = "Geçici",
					Surname = "Kullanıcı",
					Email = "belirsiz@gmail.com",
					Phone = "12345647890",
					Password = "belirsiz123",
					IsEmailConfirm = true
				},
				new User
				{
					UserId = 2,
					Name = "Zahide",
					Surname = "Uzun",
					Email = "zahide@gmail.com",
					Phone = "12345678906",
					Password = "zahide123",
					IsEmailConfirm = true
				},
				new User
				{
					UserId = 3,
					Name = "İskender",
					Surname = "İşcan",
					Email = "iskender@gmail.com",
					Phone = "23567890112",
					Password = "iskender123",
					IsEmailConfirm = true
				},
				new User
				{
					UserId = 4,
					Name = "Melike",
					Surname = "Memiş",
					Email = "melike@gmail.com",
					Phone = "23567890133",
					Password = "melike123",
					IsEmailConfirm = true
				},
				new User
				{
					UserId = 5,
					Name = "Berkay",
					Surname = "Engin",
					Email = "berkay@gmail.com",
					Phone = "2345689015",
					Password = "berkay123",
					IsEmailConfirm = true
				},
				new User
				{
					UserId = 6,
					Name = "Yekta",
					Surname = "Büyükkaya",
					Email = "yekta@gmail.com",
					Phone = "2356789016",
					Password = "yekta123",
					IsEmailConfirm = true
				}
			};

			context.Users.AddOrUpdate(c => c.UserId, users.ToArray());
			context.SaveChanges();

			var userSocialMedias = new List<UserSocialMedia>
			{
				new UserSocialMedia { UserSocialMediaId = 1, UserId = 1, SocialMediaId = 1, Email = "zahide@gmail.com", Password = "facebookpassword" },
				new UserSocialMedia { UserSocialMediaId = 2, UserId = 1, SocialMediaId = 2, Email = "zahide@gmail.com", Password = "twitterpassword" },
				new UserSocialMedia { UserSocialMediaId = 3, UserId = 2, SocialMediaId = 3, Email = "iskender@gmail.com", Password = "instagrampassword" }
			};


			context.UserSocialMedias.AddOrUpdate(c => c.UserSocialMediaId, userSocialMedias.ToArray());
			context.SaveChanges();

			var logTypes = new List<LogType>
			{
				new LogType { LogTypeId = 1, LogTypeDescription = "Information" },
				new LogType { LogTypeId = 2, LogTypeDescription = "Warning" },
				new LogType { LogTypeId = 3, LogTypeDescription = "Error" },
				new LogType { LogTypeId = 4, LogTypeDescription = "SuccessLogin" },
				new LogType { LogTypeId = 5, LogTypeDescription = "LoginFailed" }
			};
			context.LogTypes.AddOrUpdate(c => c.LogTypeId, logTypes.ToArray());
			context.SaveChanges();

			var logs = new List<Log>
			{
				new Log { LogId = 1, LogTypeId = 1, UserId = 1, LogDescription = "User logged in.", LogTime = DateTime.Now },
				new Log { LogId = 2, LogTypeId = 2, UserId = 2, LogDescription = "Invalid password entered.", LogTime = DateTime.Now },
				new Log { LogId = 3, LogTypeId = 3, UserId = 1, LogDescription = "Database connection error.", LogTime = DateTime.Now },
				new Log { LogId = 4, LogTypeId = 4, UserId = 3, LogDescription = "User login is success.", LogTime = DateTime.Now },
				new Log { LogId = 5, LogTypeId = 5, UserId = 4, LogDescription = "User login is successful.", LogTime = DateTime.Now },

			};
			context.Logs.AddOrUpdate(c => c.LogId, logs.ToArray());
			context.SaveChanges();

			base.Seed(context);
		}
    }
}
