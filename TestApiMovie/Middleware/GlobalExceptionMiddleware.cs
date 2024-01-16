using CorrelationId.Abstractions;
using Newtonsoft.Json;

namespace TestApiMovie.Middleware
{
    public class GlobalExceptionMiddleware
    {
        public readonly RequestDelegate _next;
        public readonly ICorrelationContextAccessor _correlationContextAccessor;

        public GlobalExceptionMiddleware(RequestDelegate next, ICorrelationContextAccessor correlationContextAccessor)
        {
            _next = next;
            _correlationContextAccessor = correlationContextAccessor;
        }

        public async Task Invoke(HttpContext context, IWebHostEnvironment environment, ILoggerFactory loggerFactory)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex) 
            {
                await HandleExceptionAsync(context, ex, environment,
                    _correlationContextAccessor.CorrelationContext.CorrelationId, loggerFactory.CreateLogger(ex.Source));
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception ,IWebHostEnvironment environment,
            string correlationId, ILogger logger)
        {
            var exCode = StatusCodes.Status500InternalServerError;
            string prodMessage = String.Empty;
            string correlationIdMessage = $"Request CorrelationId is '{correlationId}'";

            logger?.LogError(exception, $"{correlationIdMessage}:{exception.Message}");

            var result = environment.IsDevelopment() ?
                JsonConvert.SerializeObject(new { error = exception.Message, correlationId, stackTrace = exception.Message }, Formatting.None, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }) :
                JsonConvert.SerializeObject(new { error = $"Error occured while processing your request. {correlationIdMessage}{prodMessage}" });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = exCode;
            return context.Response.WriteAsync(result);

        }
    }
}
