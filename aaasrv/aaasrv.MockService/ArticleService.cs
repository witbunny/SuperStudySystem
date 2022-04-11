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
		public void Edit(int id, EditModel model)
		{
			throw new NotImplementedException();
		}

		public EditModel Find(int id)
		{
			throw new NotImplementedException();
		}

		public SingleModel GetById(int id)
		{
			throw new NotImplementedException();
		}

		public void Publish(NewModel model, int currentUserId)
		{
			throw new NotImplementedException();
		}

		public int Publish(NewModel model)
		{
			throw new NotImplementedException();
		}
	}
}
