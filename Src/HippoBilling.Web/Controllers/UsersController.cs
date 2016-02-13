using HippoBilling.Core.Enum;
using HippoBilling.Core.Exception;
using HippoBilling.Domain.Accounts;
using HippoBilling.Processor.Commands.Accounts;
using HippoBilling.Service.Accounts;
using HippoBilling.Web.Models.Users;
using HippoBilling.Web.Mvc.Controllers;
using HippoBilling.Web.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HippoBilling.Web.Controllers
{
    [RoutePrefix("users")]
    public class UsersController : HippoControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("get-user")]
        public JsonResult GetUser(Guid id)
        {
            var user = _userService.GetUser(id);
            if (user == null) throw new ErrorException("The user does not exist.");
            var model = new UserJsonModel { 
                Id=user.Id,
                Name=user.Name,
                Email=user.Email,
                Role= user.Role.GetText(),
                Active=user.Active
            };
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        [Route("get-users")]
        public JsonResult GetUsers(Guid practiceId,string keyword,bool active)
        {
            var users = _userService.GetPracticUsers(practiceId,keyword, active).Select(x => new UserJsonModel
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Role=x.Role.GetText(),
                Active = x.Active
            });
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("save-user")]
        public JsonResult SaveUser(SaveUserCommand command)
        {
            CommandService.Execute(command);
            return Json(new CommandResult { Success=true});
        }

        [HttpPost]
        [Route("create-user")]
        public JsonResult CreateUser(CreateUserCommand command)
        {
            command.Id = Guid.NewGuid();
            CommandService.Execute(command);

            return Json(new UserJsonModel
            {
                Id = command.Id,
                Name = command.Name,
                Email = command.Email,
                Role= Role.Custom.GetText(),
                Active = command.Active
            });
        }
        [HttpPost]
        [Route("active-users")]
        public JsonResult ActiveUsers(ActiveUsersCommand command)
        {
            CommandService.Execute(command);
            return Json(new CommandResult { Success=true});
        }

        [Route("get-permissions")]
        public JsonResult GetPermissions(Guid practiceId, Guid userId)
        {
            var model = _userService.GetUserPermissions(practiceId, userId).Select(x=>new UserPermissionJsonModel()
            {
                Id=x.ModuleId,
                Name = x.Module.Name,
                Level = x.Module.Level,
                FullControl = x.FullControl,
                View = x.View,
                Edit = x.Edit,
                Delete = x.Delete
            });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [Route("save-permissions")]
        [HttpPost]
        public JsonResult SavePermissions(SaveUserPermissionCommand command)
        {
            CommandService.Execute(command);
            return Json(new CommandResult { Success = true });
        }
    }
}