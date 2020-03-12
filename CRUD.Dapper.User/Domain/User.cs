﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Dapper.User.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Alias { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
