using aaabll.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aaatool.DbFactory
{
	class Program
	{
		static void Main(string[] args)
		{
			Helper.GetContext().Database.Delete();
			Helper.GetContext().Database.Create();

			UserFactory.Create();
			ArticleFactory.Create();


			Console.Read();
		}
	}
}
