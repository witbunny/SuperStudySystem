using aaabll.Entities;
using aaabll.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace aaatool.DbFactory
{
	class ArticleFactory
	{
		internal static void Create()
		{
			Article md5 = publish("md5简介", "md5", UserFactory.leo, 5);
			Article use = publish("md5应用", "应用", UserFactory.tik, 6);
		}

		private static Article publish(string title, string filename, User author, int day)
		{
			Article article = new Article
			{
				Title = title,
				Body = read(filename),
				Author = author
			};

			article.Publish();

			PropertyInfo ct = typeof(Article).GetProperty("CreateTime", BindingFlags.Public | BindingFlags.Instance);
			ct.SetValue(article, Helper.BaseLine.AddDays(day));

			ArticleRepository articleRepository = new ArticleRepository(Helper.GetContext());
			//UserRepository userRepository = new UserRepository(Helper.GetContext());
			//userRepository.LoadProxy(article.Author.Id);
			articleRepository.Add(article);

			return article;
		}

		private static string read(string name)
		{
			string path = Environment.CurrentDirectory.Replace("\\bin\\Debug", string.Empty);
			return File.ReadAllText(Path.Combine(path, "Articles", $"{name}.txt"));
		}
	}
}
