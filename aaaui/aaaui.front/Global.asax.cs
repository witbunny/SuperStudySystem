#if UI
using aaasrv.MockService;
#else
using aaasrv.ProdService;
#endif

using aaasrv.ServiceInterface;
using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace aaaui.front
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			ContainerBuilder builder = new ContainerBuilder();

			builder.RegisterControllers(typeof(MvcApplication).Assembly);
			builder.RegisterFilterProvider();

			//builder.RegisterType<ArticleService>().As<IArticleService>();
			//builder.RegisterType<LogService>().As<ILogService>();
			builder.RegisterAssemblyTypes(typeof(LogService).Assembly).AsImplementedInterfaces();

			IContainer container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}
	}
}
