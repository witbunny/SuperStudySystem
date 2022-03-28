using aaaglb.Global;
using aaasrv.ServiceInterface;
using aaasrv.ViewModel;
using aaasrv.ViewModel.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aaaui.front.Controllers
{
	public class LogController : Controller
    {
        private ILogService logService;

		public LogController()
		{
            logService = new aaasrv.ProdService.LogService();
		}
        
        public ActionResult On()
        {
            return View();
        }

        [HttpPost]
        public ActionResult On(OnModel model)
        {
            UserModel existUser = logService.Find(model.Name);

			if (existUser == null)
			{
                ModelState.AddModelError("Name", "* 用户名不存在");
                return View(model);
			}

			if (existUser.Password != model.Password.MD5Encrypt())
			{
                ModelState.AddModelError("Password", "* 用户名或密码错误");
                return View(model);
            }

            int userId = existUser.Id;
            string userPwd = existUser.Password;

            HttpCookie cookie = new HttpCookie(Keys.User);
            cookie.Values.Add(Keys.Id, userId.ToString());
            cookie.Values.Add(Keys.Password, userPwd);
            Response.Cookies.Add(cookie);

            return View();
        }
    }
}