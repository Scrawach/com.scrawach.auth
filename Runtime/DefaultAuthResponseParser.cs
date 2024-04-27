using UnityEngine.Networking;

namespace Plugins.AuthService.Runtime
{
    public class DefaultAuthResponseParser : IAuthResponseParser
    {
        public AuthWebResponse Parse(UnityWebRequest request) =>
            request.result switch
            {
                UnityWebRequest.Result.Success => ParseSuccessRequest(request),
                UnityWebRequest.Result.ConnectionError => AuthWebResponse.Error("Connection error"),
                UnityWebRequest.Result.ProtocolError => AuthWebResponse.Error("Protocol error"),
                _ => AuthWebResponse.Error("Unknown error")
            };

        private AuthWebResponse ParseSuccessRequest(UnityWebRequest request)
        {
            var content = DownloadHandlerBuffer.GetContent(request);
            return int.TryParse(content, out var userId) 
                ? AuthWebResponse.Success(content) 
                : AuthWebResponse.Error(content);
        }
    }
}