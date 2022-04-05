using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aaabll.Entities
{
	public class Article : Entity
	{
		public string Title { get; set; }
		public string Body { get; set; }

		public User Author { get; set; }

		public void Publish()
		{
			CreateTime = DateTime.Now;
		}
	}
}
