using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aaabll.Entities
{
    public class User : Entity
    {
        public User InvitedBy { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }

        public string IconPath { get; set; }

        public string Email { get; set; }
        public int Code { get; set; }
        public bool HasValidated { get; set; }

        public IList<Article> Articles { get; set; }

        public void Register()
		{

		}
    }
}
