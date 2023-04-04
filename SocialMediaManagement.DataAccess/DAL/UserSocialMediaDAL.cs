using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaManagement.DataAccess.Context;
using SocialMediaManagement.DataAccess.Repositories;
using SocialMediaManagement.DataAccess.VM;

namespace SocialMediaManagement.DataAccess.DAL
{
	public class UserSocialMediaDAL : Repository<UserSocialMediaDAL>
	{
		public UserLoginVM UserSocialMediaLogin(int userId, int socialMediaId, string email, string password)
		{
			using (SocialMediaContext socialMediaContext = new SocialMediaContext())
			{
				var result = (from usm in socialMediaContext.UserSocialMedias
					join u in socialMediaContext.Users on usm.UserId equals u.UserId
					where usm.UserId == userId
					      && usm.SocialMediaId == socialMediaId
					      && (usm.Email == email || usm.Username==email)
					      && usm.Password == password
					select new UserLoginVM()
					{
						Email = usm.Email,
						Name = u.Name,
						Surname = u.Surname,
						Username = u.Username

					}).SingleOrDefault();

				return result;
			}
		}

	}
}
