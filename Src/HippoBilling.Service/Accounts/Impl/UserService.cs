using System.Reflection;
using Castle.Components.DictionaryAdapter.Xml;
using HippoBilling.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Domain.Practices;

namespace HippoBilling.Service.Accounts.Impl
{
    public class UserService:ServiceBase,IUserService
    {
        public Domain.Accounts.User GetUser(Guid id)
        {
            return Repository.Get<User>(id);
        }

        public List<User> GetPracticUsers(Guid practiceId,string keyword, bool active)
        {
          var users= Repository.Query<PracticeUser>().Where(x =>x.PracticeId==practiceId&& x.User.Active == active).Select(x=>x.User);
          if (!string.IsNullOrEmpty(keyword))
          {
              users = users.Where(x => x.Name.Contains(keyword) || x.Email.Contains(keyword));
          }
          return users.ToList();
        }


        public List<UserPermission> GetUserPermissions(Guid practiceId, Guid userId)
        {
            var modules = Repository.Query<PermissionModule>();
            var permissions =
                Repository.Query<UserPermission>().Where(x => x.PracticeId == practiceId && x.UserId == userId);
            var result = (from m in modules
                        join p in permissions on m.FullName equals p.ModuleId into mp
                        from r in mp.DefaultIfEmpty()
                        select new
                        {
                            Module = m,
                            FullControl=(bool?)r.FullControl,
                            View=(bool?)r.View,
                            Edit = (bool?)r.Edit,
                            Delete=(bool?)r.Delete
                        }).OrderBy(x=>x.Module.Order).ToList();
            return result.ConvertAll(x=>new UserPermission()
            {
                ModuleId = x.Module.FullName,
                Module = x.Module,
                FullControl = x.FullControl??false,
                View = x.View??true,
                Edit = x.Edit ?? false,
                Delete = x.Delete??false,
                UserId = userId,
                PracticeId = practiceId
            });
        }
    }
}
