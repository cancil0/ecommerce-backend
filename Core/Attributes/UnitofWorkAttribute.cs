namespace Core.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class UnitofWorkAttribute : Attribute
    {
        public UnitofWorkAttribute()
        {

        }
    }
}
