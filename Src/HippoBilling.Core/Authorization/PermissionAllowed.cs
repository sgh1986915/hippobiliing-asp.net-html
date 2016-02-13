using System;
using Castle.Core.Internal;
using HippoBilling.Core.Exception;
using HippoBilling.Core.Resources;

namespace HippoBilling.Core.Authorization
{
    public class PermissionAllowed:Attribute
    {
        private readonly Type _moduleType;
        private readonly Permission _permission;
        public PermissionAllowed(Type moduleType, Permission permission)
        {
            if (!moduleType.Is<IPermissionModule>()) throw new ErrorException(CoreResource.Authoriztion_NotPermissionModule);
            _moduleType = moduleType;
            _permission = permission;
        }
    }
}
