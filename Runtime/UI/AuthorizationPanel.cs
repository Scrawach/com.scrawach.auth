using System;
using UnityEngine.UIElements;

namespace Plugins.AuthService.Runtime.UI
{
    public class AuthorizationPanel : Panel
    {
        private readonly SignInPanel _signInPanel;
        private readonly SignUpPanel _signUpPanel;

        public AuthorizationPanel(VisualElement parent) : base(parent)
        {
            _signInPanel = new SignInPanel(parent.Q<VisualElement>("sign-in-panel"));
            _signUpPanel = new SignUpPanel(parent.Q<VisualElement>("sign-up-panel"));

            _signInPanel.SignUpClicked += OnSignUpClicked;
            _signUpPanel.SignInClicked += OnSignInClicked;
        }

        private void OnSignInClicked()
        {
            _signInPanel.Show();
            _signUpPanel.Hide();
        }

        private void OnSignUpClicked()
        {
            _signUpPanel.Show();
            _signInPanel.Hide();
        }

        public event Action<Credentials> Logined
        {
            add => _signInPanel.Logined += value;
            remove => _signInPanel.Logined -= value;
        }

        public event Action<Credentials> Registered
        {
            add => _signUpPanel.Registered += value;
            remove => _signUpPanel.Registered -= value;
        }
    }
}