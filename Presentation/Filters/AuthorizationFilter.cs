using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation.Filters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
           string username= context.HttpContext.Request.Query["username"];
           string Password= context.HttpContext.Request.Query["password"]; 
            if(username!="admin" ||Password !="admin@123")
            {
                ContentResult contentResult = new ContentResult();
                contentResult.Content = "You are Not Allowed";
                context.Result = contentResult;
            }
        }
    }
}
