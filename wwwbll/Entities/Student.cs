﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wwwbll.Entities
{
    public class Student
    {
        public Student InvitedBy { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
