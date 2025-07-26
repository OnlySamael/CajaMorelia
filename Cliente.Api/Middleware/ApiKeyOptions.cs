namespace Api.Middleware
{
    public class ApiKeyOptions
    {
        public const string SectionName = "ApiKey";
        public string HeaderName { get; set; } = "X-API-KEY";
        public string Value { get; set; } = "";
    }
}
