using RealState.Infrastructure.AppSettings.Sections;

namespace RealState.Infrastructure.AppSettings
{
    public class AppSettings
    {
        public string UrlBaseWeb { get; set; }
        public AppAuthenticationSettings AppAuthenticationSettings { get; set; }
    }
}