using HippoBilling.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Domain.Practices;

namespace HippoBilling.Domain.Accounts
{
    public class User:Entity
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public HashedPassword Password { get; set; }

        public Role Role { get; set; }

        public bool Active { get; set; }
        public DateTime? LastLogin { get; set; }

        public virtual List<PracticeUser> PracticeUsers { get; set; }

        public virtual List<UserPermission> UserPermissions { get; set; } 
        public bool CheckPassword(string password)
        {
            var hashedPassword = PasswordHasher.Hash(Password.Salt, password);
            return Password.Hash == hashedPassword;
        }

        public void ChangePassword(string password)
        {
            Password = PasswordHasher.HashedPassword(password);
        }
    }
}
