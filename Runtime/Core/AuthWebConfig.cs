namespace Plugins.AuthService.Runtime.Core
{
    public class AuthWebConfig : IAuthWebConfig
    {
        public AuthWebConfig(string loginUrl, string registerUrl)
        {
            LoginUrl = loginUrl;
            RegisterUrl = registerUrl;
        }

        public string LoginUrl { get; }
        public string RegisterUrl { get; }
    }
}