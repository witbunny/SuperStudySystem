using aaaglb.Global;
using aaasrv.ServiceInterface;
using aaasrv.ViewModel;
using aaasrv.ViewModel.Article;
using aaaui.front.Filters;
using aaaui.front.Helpers;
using DevTrends.MvcDonutCaching;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.UI;

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

		//[OutputCache(Duration = 10/*, VaryByParam = "None"*//*, Location = OutputCacheLocation.Any*/)]
		//[OutputCache(CacheProfile = "ArticleIndex")]
		[DonutOutputCache(CacheProfile = "ArticleIndex")]
		public ActionResult Index(int id)
		{
			string cs = ConfigurationManager.ConnectionStrings["aaaef"].ConnectionString;
			string host = ConfigurationManager.AppSettings["host"];

			//string key = Keys.GetCacheKey(nameof(ArticleController), nameof(Index), id);

			//if (HttpContext.Cache[key] == null)
			//{
			//	//HttpContext.Cache[key] = articleService.GetById(id);

			//	HttpContext.Cache.Insert(key,
			//		articleService.GetById(id),
			//		/*new SqlCacheDependency("aaaef", "Articles")*/null,
			//		DateTime.Now.AddMinutes(1)/*DateTime.MaxValue*/,
			//		/*new TimeSpan(0, 3, 0)*/TimeSpan.Zero,
			//		CacheItemPriority.High,
			//		(k, v, r) =>
			//		{
			//			Trace.WriteLine(k);
			//			Trace.WriteLine(v);
			//			Trace.WriteLine(r);
			//		});
			//}

			//return View((SingleModel)HttpContext.Cache[key]);

			SingleModel model = articleService.GetById(id);
			return View(model);
		}

		public ActionResult New()
		{
			//throw new Exception();
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
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

			model.Body = model.Body.FilterTags();

			


			int id = articleService.Publish(model);

			return RedirectToAction("Index", new { id = id });
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

			OutputCacheManager cacheManager = new OutputCacheManager();
			cacheManager.RemoveItem("Article", "Index", new { id = id });

			return RedirectToAction("Index", new { id = id });
		}
	}
}