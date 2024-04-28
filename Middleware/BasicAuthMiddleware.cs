using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoapService.Middleware
{
    public class BasicAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private const string AuthorizationHeader = "Authorization";
        private const string BasicScheme = "Basic";

        public BasicAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string? authHeader = httpContext.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Basic"))
            {
                // Extract credentials
                string? encodedUsernamePassword = authHeader
                    .Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)[1]
                    ?.Trim();
                Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                string usernamePassword = encoding.GetString(
                    Convert.FromBase64String(encodedUsernamePassword!)
                );

                int separatorIndex = usernamePassword.IndexOf(':');

                var username = usernamePassword.Substring(0, separatorIndex);
                var password = usernamePassword.Substring(separatorIndex + 1);

                if (username == "commonws" && password == "password") // Replace "the_password" with your actual password
                {
                    await _next.Invoke(httpContext);
                }
                else
                {
                    httpContext.Response.Headers["WWW-Authenticate"] = "Basic";
                    httpContext.Response.StatusCode = 401; // Unauthorized
                    await httpContext.Response.WriteAsync("Unauthorized");
                }
            }
            else
            {
                httpContext.Response.Headers["WWW-Authenticate"] = "Basic";
                httpContext.Response.StatusCode = 401; // Unauthorized
                await httpContext.Response.WriteAsync("Unauthorized");
            }
        }
    }
}
