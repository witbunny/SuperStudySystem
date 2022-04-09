using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aaasrv.ViewModel.Email
{
	public class ActivateModel
	{
		public string Email { get; set; }
		public int Code { get; set; }

		public string Submit { get; set; }
	}
}
