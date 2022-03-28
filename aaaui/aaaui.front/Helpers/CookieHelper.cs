using aaaglb.Global;
using aaasrv.ServiceInterface;
using aaasrv.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace aaaui.front.Helpers
{
	public class CookieHelper
	{
        private static ILogService logService = new aaasrv.ProdService.LogService();

		//public CookieHelper()
		//{
		//	logService = new aaasrv.ProdService.LogService();
		//}

		public static void Delete(string name)
		{

		}

		public static int GetCurrentUserId()
		{
            NameValueCollection userCookie = HttpContext.Current.Request.Cookies[Keys.User]?.Values;
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