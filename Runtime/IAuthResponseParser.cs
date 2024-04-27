using UnityEngine.Networking;

namespace Plugins.AuthService.Runtime
{
    public interface IAuthResponseParser
    {
        AuthWebResponse Parse(UnityWebRequest request);
    }
}