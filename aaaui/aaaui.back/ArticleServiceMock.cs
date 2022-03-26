using aaasrv.ProdService;
using aaasrv.ViewModel.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aaaui.back
{
	class ArticleServiceMock
	{
		private static ArticleService articleService = new ArticleService();

		public static void PublishMock()
		{
			articleService.Publish(new NewModel { Title = "ccc", Body = "ccc" }, 1);
		}
	}
}
