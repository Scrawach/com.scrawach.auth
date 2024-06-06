using System;
using UnityEngine.UIElements;

namespace Plugins.AuthService.Runtime.UI
{
    public class SignInPanel : Panel
    {
        private readonly TextField _loginField;
        private readonly TextField _passwordField;

        private readonly Button _loginButton;
        private readonly Button _signUpButton;
        
        public SignInPanel(VisualElement parent) : base(parent)
        {
            _loginField = parent.Q<TextField>("login-field");
            _passwordField = parent.Q<TextField>("password-field");
            _loginButton = parent.Q<Button>("login-button");
            _signUpButton = parent.Q<Button>("signup-button");

            _loginButton.clicked += OnLoginButtonClicked;
        }

        public event Action<Credentials> Logined;

        public event Action SignUpClicked
        {
            add => _signUpButton.clicked += value;
            remove => _signUpButton.clicked -= value;
        }

        private void OnLoginButtonClicked() => 
            Logined?.Invoke(new Credentials(_loginField.text, _passwordField.text));
    }
}