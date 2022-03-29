using aaabll.Entities;
using aaabll.Repositories;
using aaaglb.Global;
using aaasrv.ServiceInterface;
using aaasrv.ViewModel.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aaasrv.ProdService
{
	public class RegisterService : BaseService, IRegisterService
	{
		private UserRepository userRepository;

		public RegisterService()
		{
			//SqlDbContext context = new SqlDbContext();
			userRepository = new UserRepository(Context);
		}

		public bool HasSameName(string name)
		{
			return (userRepository.Find(name) != null);
		}

		public void Register(RegisterModel model)
		{
			User newUser = new User
			{
				Name = model.Name,
				Password = model.Password.MD5Encrypt()
			};
			newUser.Register();
			int id = userRepository.Save(newUser);
		}
	}
}
