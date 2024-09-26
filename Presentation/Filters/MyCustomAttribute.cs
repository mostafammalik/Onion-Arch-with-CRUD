using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation.Filters
{
    public class MyCustomAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            ContentResult contentResult = new ContentResult();
            contentResult.Content =context.HttpContext +" Mostafa "; 
            context.Result = contentResult;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
