namespace WebTestGui.Utils
{
    public static class EnumHelpers
    {
        public static T EnumTypeFromString<T>(string text)
        {
            return (T)Enum.Parse(typeof(T), text);
        }

        public static object[] GetEnumTypes<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<object>().ToArray();
        }
    }
}
