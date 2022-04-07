using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace aaasrv.ViewModel.Register
{
	public class RegisterModel
	{
		public string Invited { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Password { get; set; }
		public string Captcha { get; set; }

		public string IconPath { get; set; }
	}
}