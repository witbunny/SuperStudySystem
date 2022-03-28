using aaasrv.ServiceInterface;
using aaasrv.ViewModel;
using aaasrv.ViewModel.Article;
using aaaui.front.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aaaui.front.Controllers
{
    public class ArticleController : BaseController
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

			//if (GetCurrentUserId() == -1)
			//{
			//	return RedirectToAction("On", "Log");
			//}

			//articleService.Publish(model, GetCurrentUserId());



			//if (CookieHelper.GetCurrentUserId() == -1)
			//{
			//    return RedirectToAction("On", "Log");
			//}

			//articleService.Publish(model, CookieHelper.GetCurrentUserId());



			articleService.Publish(model);

			return View();
        }
    }
}