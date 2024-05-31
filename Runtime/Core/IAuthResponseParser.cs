using UnityEngine.Networking;

namespace Plugins.AuthService.Runtime.Core
{
    public interface IAuthResponseParser
    {
        AuthWebResponse Parse(UnityWebRequest request);
    }
}