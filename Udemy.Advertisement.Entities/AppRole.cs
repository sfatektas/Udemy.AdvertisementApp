﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Advertisement.Entities
{
    public class AppRole : BaseEntity
    {
        public string Defination { get; set; }

        public List<AppUserRole> AppUserRoles { get; set; }
    }
}
