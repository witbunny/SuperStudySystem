using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aaaui.back
{
	class Program
	{
		static void Main(string[] args)
		{
			#region ArticleServiceMock

			ArticleServiceMock.PublishMock();

			#endregion

			Console.Read();
		}
	}
}
