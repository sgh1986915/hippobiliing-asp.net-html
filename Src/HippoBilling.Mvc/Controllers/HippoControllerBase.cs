using HippoBilling.Core.Command;
using HippoBilling.Core.Exception;
using HippoBilling.Web.Mvc.Models;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace HippoBilling.Web.Mvc.Controllers
{
    [Authorize]
    public abstract class HippoControllerBase:Controller
    {
        protected const string PRACTICEID_KEY = "practice";
        private ICommandService _commandService=null;

        protected Guid UserId
        {
            get
            {
                var identity = User.Identity.Name;
                if (string.IsNullOrEmpty(identity))
                {
                    return Guid.Empty;
                }
                return new Guid(identity);

            }
        }

        protected ICommandService CommandService
        {
            get {
                if (_commandService == null)
                {
                    _commandService = ServiceLocator.Current.GetInstance<ICommandService>();
                }
                return _commandService;
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest() &&
                filterContext.HttpContext.Request.HttpMethod.Equals("post", StringComparison.CurrentCultureIgnoreCase))
            {
                if (!ModelState.IsValid)
                {
                    filterContext.Result = Json(new CommandResult
                    {
                        Success = false,
                        Errors = ModelState.Where(x => x.Value.Errors.Any()).Select(x => new ErrorResult{ Name = x.Key, Error = x.Value.Errors[0].ErrorMessage })
                    });
                }

            }

            base.OnActionExecuting(filterContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            var exc = filterContext.Exception;
            if (exc is ErrorException)
            {
                ModelState.AddModelError("Error", exc.Message);
                filterContext.Result = Json(new CommandResult
                {
                    Success = false,
                    Errors = ModelState.Where(x => x.Value.Errors.Any()).Select(x => new ErrorResult{ Name = x.Key, Error = x.Value.Errors[0].ErrorMessage })
                });
                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.StatusCode = 200;
            }

            base.OnException(filterContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
          

            if (filterContext.HttpContext.Request.IsAjaxRequest() && filterContext.HttpContext.Request.HttpMethod.Equals("post", StringComparison.CurrentCultureIgnoreCase))
            {
                if (filterContext.Result is RedirectResult)
                {
                    var result = filterContext.Result as RedirectResult;
                    filterContext.Result = Json(new { Success = true, Redirect = result.Url });
                }
                else if (filterContext.Result is RedirectToRouteResult)
                {
                    var result = filterContext.Result as RedirectToRouteResult;
                    
                    string destinationUrl = UrlHelper.GenerateUrl(result.RouteName, null /* actionName */, null /* controllerName */, result.RouteValues,RouteTable.Routes, this.ControllerContext.RequestContext, false /* includeImplicitMvcValues */);
                    filterContext.Result = Json(new CommandResult { Success = true, Redirect = destinationUrl });
                }
            }
            base.OnActionExecuted(filterContext);
        }

        protected Guid GetPracticeId()
        {
            string param = Request.Params[PRACTICEID_KEY];
            var practiceId = Guid.Empty;
            try
            {
                if (!string.IsNullOrEmpty(param))
                {
                    practiceId = new Guid(param);
                }
            }
            catch
            {
              
            }
            return practiceId;
        }
    }
}
