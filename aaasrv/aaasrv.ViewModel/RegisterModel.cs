using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace aaasrv.ViewModel
{
	public class RegisterModel
	{
		public string InvitedBy { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Password { get; set; }
	}
}