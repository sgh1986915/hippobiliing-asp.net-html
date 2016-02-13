using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Authorization;
using HippoBilling.Core.Data;
using HippoBilling.Domain.Practices;

namespace HippoBilling.Domain.Accounts
{
    public class UserPermission:Entity
    {
        public UserPermission()
        {
            View = true;
        }

        public Guid UserId { get; set; }

        public Guid PracticeId { get; set; }
        public string ModuleId { get; set; }

        
        public virtual User User { get; set; }

        public virtual Practice Practice { get; set; }
        public virtual PermissionModule Module { get; set; }

        public bool FullControl { get; set; }

        public bool View { get; set; }

        public bool Edit { get; set; }

        public bool Delete { get; set; }
    }
}
