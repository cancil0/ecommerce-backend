using Core.Abstract;
using Core.IoC;

namespace Core.ExceptionHandler
{
    public class AppException : Exception
    {
        public string ExceptionType { get; set; }
        public AppException(string message, string exceptionType = "404", params string[] args)
            : base(Provider.Resolve<ILocalizerService>().GetResource(message, args))
        {
            ExceptionType = exceptionType;
        }
    }
}
