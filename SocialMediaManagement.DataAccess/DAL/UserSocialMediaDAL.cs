using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaManagement.DataAccess.Context;
using SocialMediaManagement.DataAccess.Repositories;

namespace SocialMediaManagement.DataAccess.DAL
{
	public class UserSocialMediaDAL : Repository<UserSocialMediaDAL>
	{
		public UserSocialMediaLogin()
		{
			using (SocialMediaContext socialMediaContext = new SocialMediaContext())
			{

			}
		}
		
	}
}
