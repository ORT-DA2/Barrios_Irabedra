using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Obligatorio.SessionInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Obligatorio.WebApi.Filters
{
    public class AuthorizationAttributeFilter : IAuthorizationFilter
    {
        private readonly ISessionLogic sessions;
        public AuthorizationAttributeFilter(ISessionLogic sessionsLogic)
        {
            this.sessions = sessionsLogic;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string privilege = context.HttpContext.Request.Headers["Authorization"];
            string email = context.HttpContext.Request.Headers["Email"];
            string password = context.HttpContext.Request.Headers["Password"];
            if (String.IsNullOrEmpty(privilege))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Access not authorized."
                };
            }
            else
            {
                /*
                if (privilege.ToLower() == "admin")
                {
                    if (!sessions.IsCorrectTokenAdmin(email, password))
                    {
                        context.Result = new ContentResult()
                        {
                            StatusCode = 403,
                            Content = "Forbidden."
                        };
                    }
                }
                else
                {
                    if (!sessions.IsCorrectTokenTourist(email, password))
                    {
                        context.Result = new ContentResult()
                        {
                            StatusCode = 403,
                            Content = "Forbidden."
                        };
                    }
                }
                */
            }
        }
    }
}
