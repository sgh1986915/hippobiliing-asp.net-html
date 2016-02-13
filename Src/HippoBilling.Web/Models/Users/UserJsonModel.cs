﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HippoBilling.Web.Models.Users
{
    public class UserJsonModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }
        public bool Active { get; set; }
    }
}