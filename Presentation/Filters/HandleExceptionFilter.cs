using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation.Filters
{
    public class HandleExceptionAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            ViewResult viewResult = new ViewResult();
            viewResult.ViewName = "Error"; 
            context.Result =viewResult;
        }
    }
}
