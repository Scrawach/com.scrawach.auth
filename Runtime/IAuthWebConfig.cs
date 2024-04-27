namespace Plugins.AuthService.Runtime
{
    public interface IAuthWebConfig
    {
        string LoginUrl { get; }
        string RegisterUrl { get; }
    }
}