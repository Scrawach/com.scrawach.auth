namespace Plugins.AuthService.Runtime.Core
{
    public interface IAuthWebConfig
    {
        string LoginUrl { get; }
        string RegisterUrl { get; }
    }
}