using Entities.EntityAttributes;

namespace Core.Extension
{
    public static class AttributeExtension
    {
        public static Attribute[] GetAttributesOfMethod(this Type elementType, string methodName)
        {
            Attribute[] attributes = Array.Empty<Attribute>();
            var methodInfo = elementType.GetMethod(methodName);

            if (methodInfo == null)
            {
                return attributes;
            }

            attributes = Attribute.GetCustomAttributes(methodInfo, true);

            return attributes;
        }

        public static Attribute[] GetAttributesOfProperty(this Type elementType)
        {
            var properties = elementType.GetProperties();
            Attribute[] attributes = Array.Empty<Attribute>();

            foreach (var property in properties)
            {
                attributes = Attribute.GetCustomAttributes(property, true);
            }

            return attributes;
        }

    }
}
