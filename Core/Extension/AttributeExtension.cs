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

        public static Attribute[] GetAttributesOfProperty(this Type elementType, string propertyName)
        {
            Attribute[] attributes = Array.Empty<Attribute>();
            var propertyInfo = elementType.GetProperty(propertyName);

            if (propertyInfo == null)
            {
                return attributes;
            }

            attributes = Attribute.GetCustomAttributes(propertyInfo, true);

            return attributes;
        }

    }
}
