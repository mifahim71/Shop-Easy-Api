namespace ShopEasyApi.Exceptions
{
    public class InvalidUserCredentialException : Exception
    {
        public InvalidUserCredentialException(string message) : base(message) { }
    }
}
