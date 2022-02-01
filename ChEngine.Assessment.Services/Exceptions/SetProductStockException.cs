namespace ChEngine.Assessment.Services.Exceptions
{
    public class SetProductStockException : Exception
    {
        public SetProductStockException(Exception ex) : base(ex.Message, ex)
        { }
    }
}
