using aaasrv.ProdService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aaaui.front.Filters
{
	public class ContextPerRequest : IActionFilter
	{
		public void OnActionExecuted(ActionExecutedContext filterContext)
		{
			//if (!filterContext.IsChildAction)
			//{
				if (filterContext.Exception == null)
				{
					BaseService.CommitTransaction();
				}
				else
				{
					BaseService.RollbackTransaction();
				}
			//} //else nothing
		}

		public void OnActionExecuting(ActionExecutingContext filterContext)
		{
			//throw new NotImplementedException();
		}
	}
}