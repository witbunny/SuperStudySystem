﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
    }
}
