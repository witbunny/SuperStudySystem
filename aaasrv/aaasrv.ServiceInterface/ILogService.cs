using aaasrv.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aaasrv.ServiceInterface
{
	public interface ILogService
	{
		UserModel Find(string name);
		UserModel Find(int id);
	}
}
