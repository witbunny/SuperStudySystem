using aaasrv.ServiceInterface;
using aaasrv.ViewModel.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aaaui.front.Controllers
{
    public class ArticleController : Controller
    {
        private IArticleService articleService;

		public ArticleController()
		{
            articleService = new aaasrv.ProdService.ArticleService();
            //articleService = new aaasrv.MockService.ArticleService();
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

            articleService.Publish(model, currentUserId);

            return View();
        }
    }
}