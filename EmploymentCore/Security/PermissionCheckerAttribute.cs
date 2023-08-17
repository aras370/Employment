using EmploymentCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class PermissionCheckerAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        int _permissionId = 0;

        IUser _user;

        public PermissionCheckerAttribute(int permissionId)
        {
            _permissionId = permissionId;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            _user = (IUser)context.HttpContext.RequestServices.GetService(typeof(IUser));


            if (context.HttpContext.User.Identity.IsAuthenticated)
            {

                var userName = context.HttpContext.User.Identity.Name;

                if (!_user.CheckUserPermission(_permissionId, userName))
                {
                    context.Result = new RedirectResult("/Account/AccessDenied");

                }


            }

            else
            {
                context.Result = new RedirectResult("/Home/Login");
            }
        }
    }
}
