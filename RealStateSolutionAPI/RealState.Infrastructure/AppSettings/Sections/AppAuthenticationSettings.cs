namespace RealState.Infrastructure.AppSettings.Sections
{
    public class AppAuthenticationSettings
    {
        public string SecretString { get; set; }
        public string UrlGeneraToken { get; set; }
        public string AudienceToken { get; set; }
    }
}