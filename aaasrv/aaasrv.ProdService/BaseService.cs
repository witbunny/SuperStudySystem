using aaabll.Entities;
using aaabll.Repositories;
using aaaglb.Global;
using aaasrv.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
            SqlDbContext context = new SqlDbContext();
            userRepository = new UserRepository(context);
        }

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
