namespace Company.Graphql.Blocks.Common.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsAssignableToGenericType(this Type givenType, Type genericType)
        {
            var hasMatchingGenericTypeInterface = givenType
                .GetInterfaces()
                .Any(interfaceType =>
                    interfaceType.IsGenericType &&
                    interfaceType.GetGenericTypeDefinition() == genericType);

            if (hasMatchingGenericTypeInterface)
            {
                return true;
            }

            if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
            {
                return true;
            }

            Type? baseType = givenType.BaseType;

            return baseType is not null && IsAssignableToGenericType(baseType, genericType);
        }

        public static bool IsImplementationOf(this Type givenType, Type interfaceType)
        {
            return givenType
                .GetInterfaces()
                .Any(interfaceType.Equals);
        }

        public static bool IsSubClassofRawGeneric(this Type type, Type genericType)
        {
            Type? typeToCheck = type;

            while(typeToCheck is not null && !typeToCheck.IsEquivalentTo(typeof(object)))
            {
                Type currentType = typeToCheck.IsGenericType
                    ? typeToCheck.GetGenericTypeDefinition()
                    : typeToCheck;

                if (currentType == genericType)
                {
                    return true;
                }

                typeToCheck = typeToCheck.BaseType;
            }

            return false;
        }
    }
}