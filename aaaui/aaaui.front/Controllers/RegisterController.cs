using aaabll.Entities;
using aaabll.Repositories;
using aaaui.front.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aaaui.front.Controllers
{
    public class RegisterController : Controller
    {
        private UserRepository userRepository;

		public RegisterController()
		{
            SqlDbContext context = new SqlDbContext();
            userRepository = new UserRepository(context);
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

			if (userRepository.Find(model.Name) != null)
			{
                ModelState.AddModelError("Name", "* 用户名不能重复");
                return View(model);
            }

            User newUser = new User
            {
                Name = model.Name,
                Password = model.Password
            };
            newUser.Register();
            int id = userRepository.Save(newUser);

            return View();
        }
    }
}