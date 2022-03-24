using wwwbll.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wwwbll.Repositories
{
    public class StudentRepository
    {
        public Student Find(int id)
        {
            throw new NotImplementedException();
        }

        public Student Find(string name)
        {
            SqlDbContext context = new SqlDbContext();
            return context.Students.Where(s => s.Name == name).SingleOrDefault();
        }
    }
}
