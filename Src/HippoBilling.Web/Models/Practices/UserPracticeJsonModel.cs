using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HippoBilling.Web.Models.Practices
{
    public class UserPracticeJsonModel
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public bool Active { get; set; }

        public bool ClickAble { get; set; }
    }
}