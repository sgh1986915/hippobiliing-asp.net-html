using HippoBilling.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Domain.Accounts
{
    public class PasswordRecovery:Entity
    {

        public virtual User User{ get; set; }
        public Guid VerioficationCode { get; set; }

        public DateTime RequestDate { get; set; }

        public bool Used { get; set; }

        public static PasswordRecovery CreateNew(User user)
        {
            return new PasswordRecovery() {
                Id=Guid.NewGuid(),
                VerioficationCode=Guid.
                NewGuid(), User = user,
                RequestDate=DateTime.Now
            };
        }

        public void Use(string password)
        {
            User.ChangePassword(password);
            Used = true;
        }
    }
}
