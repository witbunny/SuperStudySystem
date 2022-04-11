using aaasrv.ViewModel.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aaasrv.ServiceInterface
{
    public interface IArticleService
    {
        void Publish(NewModel model, int currentUserId);

        int Publish(NewModel model);
		EditModel Find(int id);
		void Edit(int id, EditModel model);
		SingleModel GetById(int id);
	}
}
