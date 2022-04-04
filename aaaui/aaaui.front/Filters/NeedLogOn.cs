using aaaglb.Global;
using aaasrv.ServiceInterface;
using aaasrv.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aaaui.front.Filters
{
	public class NeedLogOn : AuthorizeAttribute
	{
		public ILogService LogService { get; set; }

		public override void OnAuthorization(AuthorizationContext filterContext)
		{
			NameValueCollection userCookie = HttpContext.Current.Request.Cookies[Keys.User]?.Values;
			if (userCookie == null)
			{
				filterContext.Result = new RedirectResult("/Log/On");
				return;
			}

			bool hasUserId = int.TryParse(userCookie[Keys.Id], out int currentUserId);
			if (!hasUserId)
			{
				//删除cookie
			}

			string currentUserPwd = userCookie[Keys.Password];
			if (string.IsNullOrWhiteSpace(currentUserPwd))
			{
				//删除cookie
			}

			UserModel existUser = LogService.Find(currentUserId);
			if (existUser.Password != currentUserPwd)
			{
				//删除cookie
			}

			//base.OnAuthorization(filterContext);
		}
	}
}