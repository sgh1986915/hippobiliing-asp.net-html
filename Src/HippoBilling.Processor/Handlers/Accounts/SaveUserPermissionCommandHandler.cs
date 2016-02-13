using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Exception;
using HippoBilling.Domain.Accounts;
using HippoBilling.Domain.Practices;
using HippoBilling.Processor.Commands.Accounts;

namespace HippoBilling.Processor.Handlers.Accounts
{
   public class SaveUserPermissionCommandHandler:CommandHandlerBase<SaveUserPermissionCommand>
   {
       public override void Handle(SaveUserPermissionCommand command)
       {
           if(command.UserPermissions==null||command.UserPermissions.Count==0) throw new ErrorException("There is no permission.");
           var user = Repository.Get<User>(command.UserId);
           if (user == null) throw new ErrorException("The user account does not exist.");
           var practice = Repository.Get<Practice>(command.PracticeId);
           if (practice == null) throw new ErrorException("The practice does not exist.");

           var permissions =
               Repository.Query<UserPermission>()
                   .Where(x => x.UserId == command.UserId && x.PracticeId == command.PracticeId);
           Repository.DeleteRange(permissions);

           var pendingPermissions = command.UserPermissions.Select(x => new UserPermission()
           {
               User = user,
               Practice = practice,
               ModuleId=x.Id,
               FullControl = x.FullControl,
               View = x.View,
               Edit = x.Edit,
               Delete=x.Delete
           });

           Repository.CreateRange(pendingPermissions);

       }
   }
}
