namespace ShopEasyApi.Exceptions
{
    public class DuplicateUserCredentialException : Exception
    {
        public DuplicateUserCredentialException(string message) : base(message) { }
    }
}
