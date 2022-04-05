using aaabll.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aaatool.DbFactory
{
	class Helper
	{
		private static SqlDbContext context;
		static Helper()
		{
			context = new SqlDbContext();
		}

		internal static readonly DateTime BaseLine = DateTime.Now.AddDays(-10);

		internal static SqlDbContext GetContext() => context;
	}
}
