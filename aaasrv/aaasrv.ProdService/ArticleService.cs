﻿using aaabll.Entities;
using aaabll.Repositories;
using aaasrv.ServiceInterface;
using aaasrv.ViewModel.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aaasrv.ProdService
{
	public class ArticleService : IArticleService
	{
        private ArticleRepository articleRepository;
        private UserRepository userRepository;

		public ArticleService()
		{
            SqlDbContext context = new SqlDbContext();
            articleRepository = new ArticleRepository(context);
            userRepository = new UserRepository(context);
        }

        public void Publish(NewModel model, int currentUserId)
		{
            Article article = new Article
            {
                Title = model.Title,
                Body = model.Body
            };

            //User author = userRepository.Find(currentUserId);
            User author = userRepository.LoadProxy(currentUserId);
            article.Author = author;

            //articleRepository.context.Set<User>().Attach(author);
            articleRepository.Save(article);
        }
	}
}
