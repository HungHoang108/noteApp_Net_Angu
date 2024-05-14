namespace backend.Authentication
{
    public class ApiKeyAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public ApiKeyAuthMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(AuthConstants.ApiKeyHeaderName, out var extractedapikey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("unauthorized: api key is missing." + extractedapikey);
                return;
            }

            var apikey = _configuration.GetValue<string>(AuthConstants.ApiKeySectionName);

            if (!apikey.Equals(extractedapikey.ToString()))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("unauthorized: invalid api key.");
                return;
            }

            await _next(context);
        }

    }


}
