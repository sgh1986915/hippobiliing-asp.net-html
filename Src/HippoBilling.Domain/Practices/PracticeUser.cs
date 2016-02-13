using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Data;
using HippoBilling.Domain.Accounts;

namespace HippoBilling.Domain.Practices
{
    public class PracticeUser:Entity
    {

        public Guid UserId { get; set; }
        public Guid PracticeId { get; set; }

        public bool ShowInTab { get; set; }
        public virtual User User { get; set; }

        public virtual Practice Practice { get; set; }
    }
}
