using aaasrv.ServiceInterface;
using aaasrv.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aaasrv.MockService
{
	public class RegisterService : IRegisterService
	{
		public bool HasSameName(string name)
		{
			throw new NotImplementedException();
		}

		public void Register(RegisterModel model)
		{
			throw new NotImplementedException();
		}
	}
}
