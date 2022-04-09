using aaasrv.ViewModel.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aaasrv.ServiceInterface
{
	public interface IEmailService
	{
		void Send(ActivateModel model);
		Task SendAsync(ActivateModel model);
		bool Validate(int uid, int code);
	}
}
