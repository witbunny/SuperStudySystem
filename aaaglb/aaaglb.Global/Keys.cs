using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aaaglb.Global
{
	public class Keys
	{

		public const string User = "User";
		public const string Id = "Id";
		public const string Password = "Password";
		public const string DbContext = "DbContext";
		public const string Captcha = "Captcha";

		public static string GetCacheKey(string controller, string action, params object[] parameters)
		{
			return $"{controller}-{action}-" + string.Join("_", parameters);
		}
	}
}