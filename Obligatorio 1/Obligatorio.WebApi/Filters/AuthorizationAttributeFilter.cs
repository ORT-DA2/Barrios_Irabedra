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
            string token = context.HttpContext.Request.Headers["Authorization"];
            if (String.IsNullOrEmpty(token))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Access not authorized."
                };
            }
            else
            {
                if (!sessions.IsCorrectToken(token.ToLower()))
                {
                    context.Result = new ContentResult()
                    {
                        StatusCode = 403,
                        Content = "Forbidden."
                    };
                }
            }
        }
    }
}
