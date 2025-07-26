namespace Api.Middleware
{
    public static class ApiKeyMiddlewareExtensions
    {
        public static IApplicationBuilder UseApiKeyMiddleware(this IApplicationBuilder app)
            => app.UseMiddleware<ApiKeyMiddleware>();
    }
}
