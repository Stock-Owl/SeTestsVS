using Newtonsoft.Json.Linq;

namespace WebTestGui
{
    public class Options
    {
        public List<IOption> m_Options = new List<IOption>();

        public static IOption CreateOptionByType(string optionType)
        {
            var optionTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IOption).IsAssignableFrom(p) && !p.IsInterface);

            Type matchingType = optionTypes.FirstOrDefault(t =>
            {
                var instance = (IOption)Activator.CreateInstance(t)!;
                return instance.m_OptionName == optionType;
            })!;

            if (matchingType != null)
            {
                return (IOption)Activator.CreateInstance(matchingType)!;
            }

            return null!;
        }
    }

    public interface IOption
    {
        public string m_OptionName { get; set; }

        public object GetData();
        public void SetData(JToken jSondata);

        public MainForm m_ParentForm { get; set; }
    }
}
