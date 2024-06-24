namespace HNG.Api.Client.Extensions
{
    /// <summary>
    /// Ip middleware
    /// </summary>
    public class IpInfoMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="next"></param>
        public IpInfoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invoke method
        /// </summary>
        public async Task InvokeAsync(HttpContext context, IpInfoService ipInfoService)
        {
            if (context.Request.Path.StartsWithSegments("/api/hello"))
            {
                var ipAddress = context.Connection.RemoteIpAddress?.ToString();

                if (!string.IsNullOrEmpty(ipAddress))
                {
                    var ipInfo = await ipInfoService.GetIpInfoAsync(ipAddress);
                    context.Items["IpInfo"] = ipInfo;
                }
            }

            await _next(context);
        }
    }
}
