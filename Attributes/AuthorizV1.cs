using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PingChecker.Attribtes
{
    public class AuthorizV1 : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                var jsonResponse = new
                {
                    message = "User is not authenticated."
                };

                var result = new JsonResult(jsonResponse)
                {
                    StatusCode = 401,
                };

                context.Result = result;
            }
        }
    }
}
