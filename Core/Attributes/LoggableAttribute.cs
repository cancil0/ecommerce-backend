namespace Core.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class LoggableAttribute : Attribute
    {
        public bool IsRequestLoggable { get; set; } = true;
        public bool IsResponseLoggable { get; set; } = true;
    }
}
