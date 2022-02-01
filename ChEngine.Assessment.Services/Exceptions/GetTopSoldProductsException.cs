namespace ChEngine.Assessment.Services.Exceptions
{
    public class GetTopSoldProductsException : Exception
    {
        public GetTopSoldProductsException(Exception ex) : base(ex.Message, ex)
        { }
    }
}
