using Newtonsoft.Json.Linq;

namespace WebTestGui
{
    public class DriverOptions
    {
        public List<IDriverOption> m_DriverOptions = new List<IDriverOption>();

        public static IDriverOption CreateDriverOptionByType(string driverOptionType)
        {
            var optionTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IDriverOption).IsAssignableFrom(p) && !p.IsInterface);

            Type matchingType = optionTypes.FirstOrDefault(t =>
            {
                var instance = (IDriverOption)Activator.CreateInstance(t)!;
                return instance.m_DriverOptionName == driverOptionType;
            })!;

            if (matchingType != null)
            {
                return (IDriverOption)Activator.CreateInstance(matchingType)!;
            }

            return null!;
        }
    }

    public interface IDriverOption
    {
        public string m_DriverOptionName { get; set; }

        public object GetData();
        public void SetData(JToken jSondata);

        public MainForm m_ParentForm { get; set; }
    }
}
