using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SchoolApp.Web
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public static readonly List<string> NotAuthLink = new List<string> { "/Entry/Login" };
        public async Task Invoke(HttpContext context)
        {
            if (!NotAuthLink.Contains(context.Request.Path))
                if (context.Session.IsOnline() == false)
                    context.Response.Redirect("/Entry/Login");
            await _next.Invoke(context);
        }
    }
}
