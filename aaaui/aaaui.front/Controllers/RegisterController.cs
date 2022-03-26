using aaasrv.ServiceInterface;
using aaasrv.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aaaui.front.Controllers
{
    public class RegisterController : Controller
    {
        private IRegisterService registerService;

		public RegisterController()
		{
            registerService = new aaasrv.ProdService.RegisterService();
            //registerService = new aaasrv.MockService.RegisterService();
		}

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(RegisterModel model)
        {
			if (!ModelState.IsValid)
			{
                return View(model);
			}

			if (registerService.HasSameName(model.Name))
			{
                ModelState.AddModelError("Name", "* 用户名不能重复");
                return View(model);
            }

            registerService.Register(model);

            return View();
        }
    }
}