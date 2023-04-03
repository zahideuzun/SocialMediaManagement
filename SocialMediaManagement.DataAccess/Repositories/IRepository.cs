using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaManagement.DataAccess.Repositories
{
	public interface IRepository<T> where T : class
	{
		List<T> GetAll();
		T GetById(object id);
		List<T> GetByFunc(Expression<Func<T, bool>> predicate);
		int Insert(T entity);
		int Delete(T entity);
		int Update(T entity);
	}
}
