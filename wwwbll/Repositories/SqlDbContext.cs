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
	class SqlDbContext : DbContext
	{
		public SqlDbContext() : base("wwwef")
		{
			Database.Log = s =>
			{
				Console.Write(s);
				Debug.Write(s);
			};
		}

		public DbSet<Student> Students { get; set; }
	}
}
