namespace Entities.EntityAttributes
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple = true)]
    public class NotLoggablePropertyAttribute : Attribute
    {
    }
}
