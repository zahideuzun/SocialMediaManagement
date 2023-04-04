using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaManagement.DataAccess.Context;
using SocialMediaManagement.DataAccess.Entities;
using SocialMediaManagement.DataAccess.Repositories;

namespace SocialMediaManagement.DataAccess.DAL
{
	public class UserDAL : Repository<User>
	{
		public int UserLogin(string email, string password)
		{
			using (SocialMediaContext socialMediaContext = new SocialMediaContext())
			{
				int? userId = socialMediaContext.Users
					.SingleOrDefault(u => u.Email == email && u.Password == password)?.UserId;
				
				return userId ?? 0;
			}
		}
	}
}
