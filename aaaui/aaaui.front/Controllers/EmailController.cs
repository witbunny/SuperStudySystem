using aaasrv.ServiceInterface;
using aaasrv.ViewModel.Email;
using aaaui.front.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace aaaui.front.Controllers
{
    public class EmailController : BaseController
    {
        private IEmailService emailService;

		public EmailController(IEmailService emailService)
		{
            //emailService = new aaasrv.ProdService.EmailService();
            this.emailService = emailService;
		}

        [NeedLogOn]
        public ActionResult Activate()
        {
            return View();
        }

		//[HttpPost]
		//[NeedLogOn]
		//public ActionResult Activate(ActivateModel model)
		//{
		//	if (model.Submit == "send")
		//	{
		//		emailService.Send(model);
		//		return View(model);
		//	}
		//	else if (model.Submit == "validate")
		//	{
		//		int uid = GetCurrentUserId();
		//		return RedirectToAction("Validate", new { uid = uid, code = model.Code });
		//	}
		//	else
		//	{
		//		throw new ArgumentException();
		//	}
		//}

		[HttpPost]
        [NeedLogOn]
        public async Task<ActionResult> Activate(ActivateModel model)
        {
            if (model.Submit == "send")
            {
                //emailService.Send(model);
                await emailService.SendAsync(model);
                return View(model);
            }
            else if (model.Submit == "validate")
            {
                int uid = GetCurrentUserId();
                return RedirectToAction("Validate", new { uid = uid, code = model.Code });
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public ActionResult Validate(int uid, int code)
        {
            bool isValid = emailService.Validate(uid, code);
            ViewBag.isValid = isValid;
            return View();
        }
    }
}