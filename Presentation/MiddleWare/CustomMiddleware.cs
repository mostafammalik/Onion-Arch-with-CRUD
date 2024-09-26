namespace Presentation.MiddleWare
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var businessStart = new TimeSpan(9, 0, 0);  // 9:00 AM
            var businessEnd = new TimeSpan(17, 0, 0);
            if (IsBetween(businessStart,businessEnd))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden; // 403 Forbidden
                await context.Response.WriteAsync("The site is only accessible during business hours (9 AM to 5 PM).");

            } 
            else
            {
                await _next.Invoke(context);
            }
        }
        public bool IsBetween(TimeSpan start, TimeSpan end)
        {
            var Time = DateTime.Now.TimeOfDay; 
            return Time >= start && Time <= end;

        }
    }
}
