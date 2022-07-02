namespace Core.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class LoggerAttribute : Attribute
    {
        public bool IsRequestLoggable { get; set; } = true;
        public bool IsResponseLoggable { get; set; } = true;
        
    }
}
