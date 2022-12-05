namespace LåsRest.CustomExceptions
{
    public class AlreadyExists : Exception
    {
        public AlreadyExists(string message) : base(message)
        {
            
        }
    }
}
