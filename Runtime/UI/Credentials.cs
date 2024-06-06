namespace Plugins.AuthService.Runtime.UI
{
    public class Credentials
    {
        public Credentials(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public string Login { get; }
        public string Password { get; }
    }
}