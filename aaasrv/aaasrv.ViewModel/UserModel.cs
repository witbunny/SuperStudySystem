using aaasrv.ViewModel.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aaasrv.ViewModel
{
	public class UserModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }

		public IList<SingleModel> Article { get; set; }
	}
}
