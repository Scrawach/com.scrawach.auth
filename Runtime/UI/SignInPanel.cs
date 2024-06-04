using UnityEngine.UIElements;

namespace Plugins.AuthService.Runtime.UI
{
    public class SignInPanel
    {
        private readonly TextField _loginField;
        private readonly TextField _passwordField;

        private readonly Button _loginButton;
        private readonly Button _signUpButton;
        
        public SignInPanel(VisualElement parent)
        {
            _loginField = parent.Q<TextField>("login-field");
            _passwordField = parent.Q<TextField>("password-field");
            _loginButton = parent.Q<Button>("login-button");
            _signUpButton = parent.Q<Button>("signup-button");
        }
    }
}