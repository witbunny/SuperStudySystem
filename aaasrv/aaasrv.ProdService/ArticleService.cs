using aaabll.Entities;
using aaabll.Repositories;
using aaasrv.ServiceInterface;
using aaasrv.ViewModel.Article;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aaasrv.ProdService
{
	public class ArticleService : BaseService, IArticleService
	{
        private ArticleRepository articleRepository;
        private UserRepository userRepository;

		public ArticleService()
		{
            //SqlDbContext context = new SqlDbContext();
            articleRepository = new ArticleRepository(Context);
            userRepository = new UserRepository(Context);
        }

		public void Edit(int id, EditModel model)
		{
            Article article = articleRepository.Find(id);
            Mapper.Map<EditModel, Article>(model, article);
            articleRepository.Update();
		}

		public EditModel Find(int id)
		{
            Article article = articleRepository.Find(id);
			if (article == null)
			{
                return null;
			}
            EditModel model = Mapper.Map<EditModel>(article);
            return model;
		}

		public void Publish(NewModel model, int currentUserId)
		{
            Article article = new Article
            {
                Title = model.Title,
                Body = model.Body
            };

            //User author = userRepository.Find(currentUserId);
            User author = userRepository.LoadProxy(currentUserId);
            article.Author = author;

            //articleRepository.context.Set<User>().Attach(author);
            articleRepository.Add(article);
        }

		public void Publish(NewModel model)
		{
			if (GetCurrentUser() == null)
			{
                throw new ArgumentException("");
			}

            //MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<NewModel, Article>());
            //IMapper mapper = config.CreateMapper();
            Article article = Mapper.Map<Article>(model);

            //Article article = new Article
            //{
            //    Title = model.Title,
            //    Body = model.Body
            //};

			//User author = userRepository.Find(currentUserId);
			//User author = userRepository.LoadProxy(currentUserId);
			//User author = userRepository.LoadProxy(GetCurrentUser().Id);
			User author = GetCurrentUser();
			article.Author = author;

            //articleRepository.context.Set<User>().Attach(author);
            articleRepository.Add(article);
        }
	}
}
