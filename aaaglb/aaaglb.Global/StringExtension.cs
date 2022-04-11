using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aaaglb.Global
{
	public static class StringExtension
	{
		public static string MD5Encrypt(this string source)
		{
			byte[] bytes = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(source));

			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < bytes.Length; i++)
			{
				sb.Append(bytes[i].ToString("x2"));
			}

			return sb.ToString();
		}

		public static string FixTags(this string inputHtml, string[] allowedTags, string[] allowedProperties)
		{
			string fixedHtml = Regex.Replace(inputHtml,
				@"<[\s\S]*?>",
				match =>
				{
					string tag = match.Value;
					Match m = Regex.Match(tag, 
						@"</?(?<tagName>\S*)[>\s/]",
						RegexOptions.IgnoreCase);
					string tagName = m.Groups["tagName"].Value.ToLower();

					if (Array.IndexOf(allowedTags, tagName) < 0)
					{
						return "";
					}
					else
					{
						string fixedProperty = Regex.Replace(tag,
							"\\S+\\s*=\\s*[\"'][\\s\\S]*?[\"']", 
							ma => 
							{
								string prop = ma.Value;
								Match pm = Regex.Match(prop, 
									@"(?<propName>\w+)[=\s]", 
									RegexOptions.IgnoreCase);
								string propName = pm.Groups["propName"].Value.ToLower();

								if (Array.IndexOf(allowedProperties, propName) < 0)
								{
									return "";
								}
								else
								{
									return prop;
								}
							}, 
							RegexOptions.IgnoreCase);
						return fixedProperty;
					}
				},
				RegexOptions.IgnoreCase);
			return fixedHtml;
		}
	}
}
