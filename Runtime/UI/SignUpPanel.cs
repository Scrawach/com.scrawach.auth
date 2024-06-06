using System;
using UnityEngine.UIElements;

namespace Plugins.AuthService.Runtime.UI
{
    public class SignUpPanel : Panel
    {
        private readonly TextField _loginField;
        private readonly TextField _passwordField;
        private readonly TextField _repeatedPasswordField;

        private readonly Button _registerButton;
        private readonly Button _signInButton;
        
        public SignUpPanel(VisualElement parent) : base(parent)
        {
            _loginField = parent.Q<TextField>("login-field");
            _passwordField = parent.Q<TextField>("password-field");
            _repeatedPasswordField = parent.Q<TextField>("repeat-password-field");
            _registerButton = parent.Q<Button>("registration-button");
            _signInButton = parent.Q<Button>("signin-button");

            _registerButton.clicked += OnRegisterButtonClicked;
        }

        public event Action<Credentials> Registered;

        public event Action SignInClicked
        {
            add => _signInButton.clicked += value;
            remove => _signInButton.clicked -= value;
        }

        private void OnRegisterButtonClicked()
        {
            if (_passwordField.text != _repeatedPasswordField.text)
                return;
            
            Registered?.Invoke(new Credentials(_loginField.text, _passwordField.text));
        }
    }
}