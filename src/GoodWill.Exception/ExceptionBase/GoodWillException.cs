namespace GoodWill.Exception.ExceptionBase
{
    public abstract class GoodWillException : System.Exception
    {
        protected GoodWillException(string message) : base(message)
        {

        }

        public abstract int StatusCode { get; }
        public abstract List<string> GetErrors();
    }
}
