using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HippoBilling.Web.Models.Users
{
    public class UserPermissionJsonModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public bool FullControl { get; set; }

        public bool View { get; set; }

        public bool Edit { get; set; }

        public bool Delete { get; set; }
    
    }
}