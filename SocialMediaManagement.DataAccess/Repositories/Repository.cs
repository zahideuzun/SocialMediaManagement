using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SocialMediaManagement.DataAccess.Context;

namespace SocialMediaManagement.DataAccess.Repositories
{
	public class Repository<T> : IRepository<T> where T : class
	{
		SocialMediaContext _socialMediaContext=null;
		private DbSet<T> _dbSet = null;

		public Repository()
		{
			_socialMediaContext = new SocialMediaContext();
			_dbSet = _socialMediaContext.Set<T>();
		}
		public Repository(SocialMediaContext socialMediaContext)
		{
			_socialMediaContext =socialMediaContext;

		}
		public int Delete(T entity)
		{
			_socialMediaContext.Entry(entity).State = EntityState.Deleted;
			_dbSet.Remove(entity);
			return _socialMediaContext.SaveChanges();
		}

		public List<T> GetAll()
		{
			return _dbSet.ToList();
		}

		public List<T> GetByFunc(Expression<Func<T, bool>> predicate)
		{
			return _dbSet.Where(predicate).ToList();
		}

		public T GetById(object id)
		{
			return _dbSet.Find(id);
		}

		public int Insert(T entity)
		{
			_dbSet.Add(entity);
			return _socialMediaContext.SaveChanges();
		}

		public int Update(T entity)
		{
			_dbSet.Attach(entity);
			_socialMediaContext.Entry(entity).State = EntityState.Modified;
			return _socialMediaContext.SaveChanges();
		}
	}
}
