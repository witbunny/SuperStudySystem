using sssdal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sssbll.Repositories
{
	public class StudentRepository
	{
		public Student Find(int id)
		{
			IDataReader reader = new StudentFacade().Find(id);

			throw new NotImplementedException();
		}

		public Student Find(string name)
		{
			throw new NotImplementedException();
		}
	}
}
