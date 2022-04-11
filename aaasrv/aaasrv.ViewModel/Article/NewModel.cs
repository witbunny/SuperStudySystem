using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aaasrv.ViewModel.Article
{
	public class NewModel
	{
		public string Title { get; set; }
		[AllowHtml]
		public string Body { get; set; }
	}
}