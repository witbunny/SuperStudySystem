﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aaabll.Entities
{
	public class Entity
	{
		public int Id { get; set; }
		public DateTime? CreateTime { get; protected set; }
	}
}
