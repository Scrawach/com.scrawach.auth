using System;
using Plugins.AuthService.Runtime.Core;
using Plugins.AuthService.Runtime.UI;
using UnityEngine;
using UnityEngine.UIElements;

namespace Plugins.AuthService._Samples
{
    public class SampleAuthorizationScreen : MonoBehaviour
    {
        public UIDocument Document;
        public string LoginUrl;
        public string RegisterUrl;

        private AuthorizationPanel _authorization;
        private AuthWebClient _client;
        
        private void Awake()
        {
            _authorization = new AuthorizationPanel(Document.rootVisualElement);
            _client = new AuthWebClient(new AuthWebConfig(LoginUrl, RegisterUrl));
        }

        private void OnEnable()
        {
            _authorization.Logined += OnLogined;
            _authorization.Registered += OnRegistered;
        }
        
        private void OnDisable()
        {
            _authorization.Logined -= OnLogined;
            _authorization.Registered -= OnRegistered;
        }

        private async void OnRegistered(Credentials credentials)
        {
            var response = await _client.Register(credentials.Login, credentials.Password);
            Debug.Log($"{response.Content}");
        }

        private async void OnLogined(Credentials credentials)
        {
            var response = await _client.Login(credentials.Login, credentials.Password);
            Debug.Log($"{response.Content}");
        }
    }
}