using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RestaurantAPI5.Middleware
{
    public class RequestTimeMiddleware : IMiddleware
    {
        private readonly ILogger<RequestTimeMiddleware> _logger;
        private Stopwatch _timer;

        public RequestTimeMiddleware(ILogger<RequestTimeMiddleware> logger)
        {
            _logger = logger;
            _timer = new Stopwatch();
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _timer.Start();
            await next.Invoke(context);
            _timer.Stop();
            var timeElapsed = _timer.ElapsedMilliseconds / 1000;
            if (timeElapsed > 4)
            {
                var message = $"Request [{context.Request.Method}] at {context.Request.Path} took {timeElapsed} seconds.";
                _logger.LogInformation(message);
            }
        }
    }
}
