using wwwbll.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wwwbll.Repositories
{
    public class UserRepository : Repository<User>
    {
		public UserRepository(SqlDbContext context) : base(context)
		{
			//context = new SqlDbContext<User>();
		}

		public User Find(int id)
        {
			return dbset.Where(e => e.Id == id).SingleOrDefault();
        }

		public User Find(string name)
		{
			//SqlDbContext context = new SqlDbContext();
			return dbset.Where(e => e.Name == name).SingleOrDefault();
			//return context.Set<User>().Where(s => s.Name == name).SingleOrDefault();
			//return context.Entities.Where(s => s.Name == name).SingleOrDefault();
		}
	}
}
