using aaaglb.Global;
using aaasrv.ServiceInterface;
using aaasrv.ViewModel.Register;
using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult Index(RegisterModel model, HttpPostedFileBase icon)
        {
			if (icon.ContentLength > 1024*800)
			{

			}

			if (icon.ContentType != "image/png")
			{

			}

            string mainName = Guid.NewGuid().ToString();
            string extensionName = Path.GetExtension(icon.FileName);

            DateTime now = DateTime.Now;
            string urlDirectory = $"\\UploadFiles\\{now.Year}\\{now.Month}\\{now.Day}";
            string phyDirectory = Server.MapPath(urlDirectory);
            Directory.CreateDirectory(phyDirectory);

            string urlPath = $"{urlDirectory}\\{mainName}{extensionName}";
            string phyPath = Server.MapPath(urlPath);

            icon.SaveAs(phyPath);
            model.IconPath = urlPath;

            

            if (registerService.HasSameName(model.Name))
            {
                ModelState.AddModelError("Name", "* 用户名不能重复");
                return View(model);
            }

            //Session.IsNewSession

            if (Session[Keys.Captcha].ToString() != model.Captcha)
			{
                Session.Remove(Keys.Captcha);
                return View(model);
			}

            if (!ModelState.IsValid)
			{
                return View(model);
			}

            registerService.Register(model);

            return View();
        }
    }
}