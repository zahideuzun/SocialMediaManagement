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
				var userId = (from user in socialMediaContext.Users
							  where user.Email == email && user.Password == password
								  select user.UserId).SingleOrDefault();

				return userId;
			}
		}
	}
}
