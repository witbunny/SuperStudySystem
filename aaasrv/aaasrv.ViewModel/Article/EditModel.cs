using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace aaasrv.ViewModel.Article
{
	public class EditModel
	{
		public string Title { get; set; }
		[AllowHtml]
		public string Body { get; set; }
	}
}
