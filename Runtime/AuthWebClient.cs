using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;

namespace Plugins.AuthService.Runtime
{
    public class AuthWebClient
    {
        private readonly IAuthWebConfig _config;
        private readonly IAuthResponseParser _parser;

        public AuthWebClient(IAuthWebConfig config) 
            : this(config, new DefaultAuthResponseParser())
        { }
        
        public AuthWebClient(IAuthWebConfig config, IAuthResponseParser parser)
        {
            _config = config;
            _parser = parser;
        }

        public async UniTask<AuthWebResponse> Login(string login, string password, CancellationToken token = default) => 
            await SendRequest(_config.LoginUrl, PackToDictionary(login, password), token);

        public async UniTask<AuthWebResponse> Register(string login, string password, CancellationToken token = default) => 
            await SendRequest(_config.RegisterUrl, PackToDictionary(login, password), token);

        private static Dictionary<string, string> PackToDictionary(string login, string password) =>
            new()
            {
                ["login"] = login,
                ["password"] = password
            };

        private async UniTask<AuthWebResponse> SendRequest(string url, Dictionary<string, string> data, CancellationToken token = default)
        {
            using var request = await UnityWebRequest
                .Post(url, data)
                .SendWebRequest()
                .WithCancellation(token);
            
            return _parser.Parse(request);
        }
    }
}