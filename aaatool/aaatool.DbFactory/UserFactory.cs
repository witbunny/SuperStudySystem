using aaabll.Entities;
using aaabll.Repositories;
using aaaglb.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aaatool.DbFactory
{
	class UserFactory
	{
		internal static User leo, tik, ash;

		internal static void Create()
		{
			leo = register("leo");
			tik = register("tik");
			ash = register("ash");
		}

		private static User register(string name)
		{
			const string pwd = "1234";
			User user = new User { Name = name, Password = pwd.MD5Encrypt() };

			user.Register();
			
			UserRepository userRepository = new UserRepository(Helper.GetContext());
			userRepository.Add(user);

			return user;
		}
	}
}
