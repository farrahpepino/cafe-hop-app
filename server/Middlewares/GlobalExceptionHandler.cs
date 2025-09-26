using Microsoft.Extenstions.Logging;
using Microsoft.AspNetCore.Http;

namespace server.Middlewares{
    public class GlobalExceptionHander{
        private readonly RequestDelegate _context;
        private readonly ILogger<GlobalExceptionHander> _logger;
        public GlobalExceptionHander (RequestDelegate context, ILogger<GlobalExceptionHander> logger){
            _context = context;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context){
            try{
                await _next(context);
            }
            catch(Exception ex){
                _logger.LogError(ex, "Unhandled exception.");

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                 var errorResponse = new{
                    status = context.Response.StatusCode,
                    error = "An unexpected error occurred",
                    detail = ex.Message,
                    timestamp = DateTime.Now
                };

                await context.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}