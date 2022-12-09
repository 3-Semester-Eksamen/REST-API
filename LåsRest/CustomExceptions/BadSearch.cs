namespace LåsRest.CustomExceptions
{
    public class BadSearch : Exception
    {
        public BadSearch(string message) : base(message)
        {
            
        }

        public BadSearch()
        {
            
        }
    }
}
