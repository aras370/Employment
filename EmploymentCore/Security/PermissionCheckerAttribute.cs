
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EmploymentCore
{
    public class PermissionCheckerAttribute : System.Web.Mvc.AuthorizeAttribute, System.Web.Mvc.IAuthorizationFilter
    {

        int _permissionId = 0;

        IUser _permission;

        public PermissionCheckerAttribute(int permissionId)
        {
            _permissionId = permissionId;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _permission = (IUser)context.HttpContext.RequestServices.GetService(typeof(IUser));


            if (context.HttpContext.User.Identity.IsAuthenticated)
            {

                

                var userName = context.HttpContext.User.Identity.Name;

                if (!_permission.CheckUserPermission(_permissionId, userName))
                {
                    context.Result = new UnauthorizedResult();

                }


            }

            else
            {
                context.Result = new UnauthorizedResult();
            }
        }

    }
}
