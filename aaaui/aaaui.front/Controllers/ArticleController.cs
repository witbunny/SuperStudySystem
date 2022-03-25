using aaabll.Entities;
using aaabll.Repositories;
using aaaui.front.Models.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aaaui.front.Controllers
{
    public class ArticleController : Controller
    {
        private ArticleRepository articleRepository;
        private UserRepository userRepository;

		public ArticleController()
		{
            SqlDbContext context = new SqlDbContext();
            articleRepository = new ArticleRepository(context);
            userRepository = new UserRepository(context);
		}

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(NewModel model)
        {
            int currentUserId = 1;

            Article article = new Article
            {
                Title = model.Title,
                Body = model.Body
            };

            //User author = userRepository.Find(currentUserId);
            User author = userRepository.LoadProxy(currentUserId);
            article.Author = author;

            //articleRepository.context.Set<User>().Attach(author);
            articleRepository.Save(article);

            return View();
        }
    }
}