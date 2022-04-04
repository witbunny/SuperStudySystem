using aaasrv.ServiceInterface;
using aaasrv.ViewModel;
using aaasrv.ViewModel.Article;
using aaaui.front.Filters;
using aaaui.front.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aaaui.front.Controllers
{
	[NeedLogOn]
	public class ArticleController : BaseController
	{
		private IArticleService articleService;

		public ArticleController(IArticleService articleService)
		{
			//#if UI
			//			articleService = new aaasrv.MockService.ArticleService();
			//#else
			//			articleService = new aaasrv.ProdService.ArticleService();
			//#endif
			
			this.articleService = articleService;
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult New()
		{
			//throw new Exception();
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


		public ActionResult Edit(int id)
		{
			//id.HasValue
			//int intid = id.Value;

			EditModel model = articleService.Find(id);

			return View(model);
		}

		[HttpPost]
		public ActionResult Edit(int id, EditModel model)
		{
			articleService.Edit(id, model);

			return View(model);
		}
	}
}