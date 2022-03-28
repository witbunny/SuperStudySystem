using aaasrv.ServiceInterface;
using aaasrv.ViewModel;
using aaasrv.ViewModel.Article;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aaaui.front.Controllers
{
    public class ArticleController : Controller
    {
        private IArticleService articleService;
        private ILogService logService;

        public ArticleController()
		{
            articleService = new aaasrv.ProdService.ArticleService();
            //articleService = new aaasrv.MockService.ArticleService();

            logService = new aaasrv.ProdService.LogService();
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
            NameValueCollection userCookie = Request.Cookies[Keys.User]?.Values;

			if (userCookie == null)
			{
                throw new Exception();
			}

            int currentUserId = int.Parse(userCookie[Keys.Id]);
            string currentUserPwd = userCookie[Keys.Password];

            UserModel existUser = logService.Find(currentUserId);

            if (existUser == null)
            {
                throw new Exception();
            }

            if (existUser.Password != currentUserPwd)
            {
                throw new Exception();
            }


            articleService.Publish(model, currentUserId);

            return View();
        }
    }
}