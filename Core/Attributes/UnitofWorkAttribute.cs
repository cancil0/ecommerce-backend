namespace Core.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class UnitofWorkAttribute : Attribute
    {
        public bool IsTransactional { get; set; }
        public bool CommitInstantly { get; set; }
        public UnitofWorkAttribute()
        {

        }
    }
}
