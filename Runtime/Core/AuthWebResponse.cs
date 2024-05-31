namespace Plugins.AuthService.Runtime.Core
{
    public class AuthWebResponse
    {
        public AuthWebResponse(bool isSuccess, string content)
        {
            IsSuccess = isSuccess;
            Content = content;
        }

        public bool IsSuccess { get; }
        public string Content { get; }

        public override string ToString() => 
            $"IsSuccess: {IsSuccess}; Content: {Content}";

        public static AuthWebResponse Success(string content) => 
            new(true, content);

        public static AuthWebResponse Error(string message) => 
            new(false, message);
    }
}