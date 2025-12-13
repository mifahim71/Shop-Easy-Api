namespace ShopEasyApi.Exceptions
{
    public class StockOutException : Exception
    {
        public StockOutException(string message) : base(message) { }
    }
}
