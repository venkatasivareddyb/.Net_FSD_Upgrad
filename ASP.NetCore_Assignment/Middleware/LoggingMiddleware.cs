namespace Asp.net_Core_Assignment_1.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("Handling request: {method} {url}",
                context.Request.Method,
                context.Request.Path);

            await _next(context);

            _logger.LogInformation("Finished handling request. Response status: {statusCode}",
                context.Response.StatusCode);
        }
    }

    // Extension method to register middleware
    public static class LoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LoggingMiddleware>();
        }
    }
}
