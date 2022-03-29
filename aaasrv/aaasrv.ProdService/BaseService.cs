using aaabll.Entities;
using aaabll.Repositories;
using aaaglb.Global;
using aaasrv.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace aaasrv.ProdService
{
	public class BaseService
	{
        private UserRepository userRepository;

		public BaseService()
		{
            //SqlDbContext context = new SqlDbContext();
            userRepository = new UserRepository(Context);
        }

        protected SqlDbContext Context
		{
            get
			{
				if (HttpContext.Current.Items[Keys.DbContext] == null)
				{
                    SqlDbContext context = new SqlDbContext();
                    context.Database.BeginTransaction();
                    HttpContext.Current.Items[Keys.DbContext] = context;
                } //else nothing
                return (SqlDbContext)HttpContext.Current.Items[Keys.DbContext];
            }
		}

        public static void CommitTransaction()
		{
            SqlDbContext context = getCurrentContext();

            if (context != null)
			{
				using (context)
				{
					using (DbContextTransaction transaction = context.Database.CurrentTransaction)
					{
                        transaction.Commit();
                    }
				}
            } //else nothing
        }

        public static void RollbackTransaction()
        {
            SqlDbContext context = getCurrentContext();

            if (context != null)
            {
                using (context)
                {
                    using (DbContextTransaction transaction = context.Database.CurrentTransaction)
                    {
                        transaction.Rollback();
                    }
                }
            } //else nothing
        }

        private static SqlDbContext getCurrentContext()
		{
            object oContext = HttpContext.Current.Items[Keys.DbContext];
            HttpContext.Current.Items.Remove(Keys.DbContext);
            return oContext as SqlDbContext;
        }


		//public static void EndTransaction()
		//{
		//	object oContext = HttpContext.Current.Items[Keys.DbContext];
		//	SqlDbContext context = oContext as SqlDbContext;

		//	if (context != null)
		//	{
		//		using (DbContextTransaction transaction = context.Database.CurrentTransaction)
		//		{
		//			try
		//			{
		//				transaction.Commit();
		//			}
		//			catch (Exception)
		//			{
		//				transaction.Rollback();
		//				throw;
		//			}
		//		}
		//	} //else nothing
		//}

		public User GetCurrentUser()
        {
            NameValueCollection userCookie = HttpContext.Current.Request.Cookies[Keys.User]?.Values;
            if (userCookie == null)
            {
                return null;
            }

            bool hasUserId = int.TryParse(userCookie[Keys.Id], out int currentUserId);
            if (!hasUserId)
            {
                //删除cookie
                //throw new ArgumentException("");
            }

            string currentUserPwd = userCookie[Keys.Password];
            if (string.IsNullOrWhiteSpace(currentUserPwd))
            {
                throw new ArgumentException("");
            }

            User existUser = userRepository.Find(currentUserId);
            if (existUser.Password != currentUserPwd)
            {
                throw new ArgumentException("");
            }

            return existUser;
        }
    }
}
