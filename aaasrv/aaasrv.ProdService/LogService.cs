using aaabll.Entities;
using aaabll.Repositories;
using aaasrv.ServiceInterface;
using aaasrv.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aaasrv.ProdService
{
	public class LogService : ILogService
	{
		private UserRepository userRepository;

		public LogService()
		{
			SqlDbContext context = new SqlDbContext();
			userRepository = new UserRepository(context);
		}

		public UserModel Find(string name)
		{
			User exist = userRepository.Find(name);
			UserModel userModel = (exist == null) ?
				null :
				new UserModel
				{
					Id = exist.Id,
					Name = exist.Name,
					Password = exist.Password
				};
			return userModel;
		}

		public UserModel Find(int id)
		{
			User exist = userRepository.Find(id);
			UserModel userModel = (exist == null) ?
				null :
				new UserModel
				{
					Id = exist.Id,
					Name = exist.Name,
					Password = exist.Password
				};
			return userModel;
		}
	}
}
