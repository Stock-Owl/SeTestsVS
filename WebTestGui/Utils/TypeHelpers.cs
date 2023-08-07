using System.Reflection;

namespace WebTestGui
{
    public static class TypeHelpers
    {
        public static T EnumTypeFromString<T>(string text)
        {
            return (T)Enum.Parse(typeof(T), text);
        }

        public static object[] GetEnumTypes<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<object>().ToArray();
        }

        public static Type GetClassFromString(string classname)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (type.Name == classname)
                    {
                        return type;
                    }
                }
            }

            return null;
        }

        public static object[] GetAllSubClasses<T>()
        {
            Type[] allTypes = Assembly.GetAssembly(typeof(T))!.GetTypes();
            List<object> subClasses = new List<object>();
            foreach (var myType in allTypes)
            {
                bool isSubType = myType.IsSubclassOf(typeof(T));

                if (isSubType)
                {
                    subClasses.Add(myType.Name);
                }
            }
            return subClasses.ToArray();
        }

        public static object[] GetAllSubClassesFromInterface<T>()
        {
            Type interfaceType = typeof(T);
            List<object> subClasses = new List<object>();

            var implementingClasses = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => interfaceType.IsAssignableFrom(t) && !t.IsInterface);

            foreach (var implementingClass in implementingClasses)
            {
                subClasses.Add(implementingClass.Name);
            }
            return subClasses.ToArray();
        }
    }
}
