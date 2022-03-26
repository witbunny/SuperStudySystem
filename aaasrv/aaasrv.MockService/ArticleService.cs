using aaasrv.ServiceInterface;
using aaasrv.ViewModel.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aaasrv.MockService
{
	public class ArticleService : IArticleService
	{
		public void Publish(NewModel model, int currentUserId)
		{
			throw new NotImplementedException();
		}
	}
}
