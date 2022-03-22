using sssmvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sssmvc.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            RegisterModel model = new RegisterModel
            {
                Name = "leo",
                Password = "1234"
            };

            return View(model);
        }
    }
}