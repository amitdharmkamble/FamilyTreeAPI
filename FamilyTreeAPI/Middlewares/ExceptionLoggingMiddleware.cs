using FamilyTreeAPI.Contexts;
using FamilyTreeAPI.Models;
using System.Net;
using System.Text.Json;

namespace FamilyTreeAPI.Middlewares
{
    public class ExceptionLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionLoggingMiddleware> _logger;

        public ExceptionLoggingMiddleware(RequestDelegate next, ILogger<ExceptionLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, CommonContext dbContext)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var errorLog = new ErrorLog
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace ?? "",
                    Path = context.Request.Path,
                    CreatedAt = DateTime.UtcNow
                };

                dbContext.ErrorLogs.Add(errorLog);
                await dbContext.SaveChangesAsync();

                _logger.LogError(ex, "Unhandled exception");

                context.Response.ContentType = "application/problem+json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var problemDetails = new
                {
                    type = "https://httpstatuses.com/500",
                    title = "Internal Server Error",
                    status = 500,
                    detail = "An unexpected error occurred. Please try again later." + "\n" + ex.Message, 
                    instance = context.Request.Path
                };

                var json = JsonSerializer.Serialize(problemDetails);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
 