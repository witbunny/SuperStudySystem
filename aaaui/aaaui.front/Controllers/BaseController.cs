using aaaglb.Global;
using aaasrv.ServiceInterface;
using aaasrv.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aaaui.front.Controllers
{
	public class BaseController : Controller
	{
        private ILogService logService;

		public BaseController()
		{
            logService = new aaasrv.ProdService.LogService();
        }

        protected int GetCurrentUserId()
		{
            NameValueCollection userCookie = Request.Cookies[Keys.User]?.Values;
            if (userCookie == null)
            {
                return -1;
            }

            bool hasUserId = int.TryParse(userCookie[Keys.Id], out int currentUserId);
            if (!hasUserId)
            {
                //删除cookie
                //throw new ArgumentException("");
            }

            string currentUserPwd = userCookie[Keys.Password];
            if (string.IsNullOrWhiteSpace(currentUserPwd))
            {
                throw new ArgumentException("");
            }

            UserModel existUser = logService.Find(currentUserId);
            if (existUser.Password != currentUserPwd)
            {
                throw new ArgumentException("");
            }

            return currentUserId;
        }
	}
}