using Core.Base.Abstract;
using Core.IoC;

namespace Core.Middleware.ExceptionMiddleware
{
    public class AppException : Exception
    {
        private static readonly ILocalizerService localizer = Provider.Resolve<ILocalizerService>();
        public string ExceptionType { get; set; }
        public AppException() : base() { }

        public AppException(string message, params string[] args) : base(string.Format(localizer.GetTranslatedValue(message), args)) { }

        public AppException(string message, string exceptionType, params string[] args) : base(string.Format(localizer.GetTranslatedValue(message), args))
        {
            ExceptionType = exceptionType;
        }
    }
}
