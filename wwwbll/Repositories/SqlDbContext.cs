using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wwwbll.Entities;

namespace wwwbll.Repositories
{
	public class SqlDbContext : DbContext
	{
		public SqlDbContext() : base("wwwef")
		{
			Database.Log = s =>
			{
				//Console.Write(s);
				Debug.Write(s);
			};
		}

		//public DbSet<User> Users { get; set; }
		//public DbSet<Article> Articles { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>();
			modelBuilder.Entity<Article>();

			base.OnModelCreating(modelBuilder);
		}
	}

	//public class SqlDbContext<T> : SqlDbContext where T : Entity
	//{
	//	public DbSet<T> Entities { get; set; }
	//}
}
