using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aaaglb.Global
{
	public static class HtmlExtension
	{
		public static string FilterTags(this string source)
		{
			string[] allowedTags =
			{
				"p", "br", 
				"ul", "ol", "li", 
				"strong", "em", "u", "s", 
				"img", "a", 

				"h1", "h2", "h3", "h4", 
				"div", "span", 
				"table", "tbody", "tr", "td"
			};

			string[] allowedProperties =
			{
				"src", "alt", 
				"href", "target", "title", "name"
			};

			

			return source.FixTags(allowedTags, allowedProperties);
		}
	}
}
