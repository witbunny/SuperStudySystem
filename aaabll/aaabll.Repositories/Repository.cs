using aaabll.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aaabll.Repositories
{
	public class Repository<T> where T : Entity, new()
	{
		//protected SqlDbContext<T> context;

		protected SqlDbContext context;
		protected DbSet<T> dbset;

		public Repository(SqlDbContext context)
		{
			//context = new SqlDbContext();
			this.context = context;
			dbset = context.Set<T>();
		}

		public int Save(T entity)
		{
			dbset.Add(entity);
			//context.Set<T>().Add(entity);
			//context.Entities.Add(entity);
			context.SaveChanges();
			return entity.Id;
		}

		public void Remove(T entity)
		{
			throw new NotImplementedException();
		}

		public T LoadProxy(int id)
		{
			T entity = new T { Id = id };
			dbset.Attach(entity);
			return entity;
		}
	}
}
