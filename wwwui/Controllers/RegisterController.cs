using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wwwbll.Entities;
using wwwbll.Repositories;
using wwwui.Models;

namespace wwwui.Controllers
{
    public class RegisterController : Controller
    {
        private StudentRepository studentRepository;
		public RegisterController()
		{
            studentRepository = new StudentRepository();
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
                return View();
			}

			if (studentRepository.Find(model.Name) != null)
			{
                ModelState.AddModelError("", "* 用户名不能重复");
			}
            return View();
        }
    }
}