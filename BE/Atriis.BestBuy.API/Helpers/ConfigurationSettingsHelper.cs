using BestBuy.Abstractions.Models;

namespace BestBuy.API.Helpers
{
    public class ConfigurationSettingsHelper
    {
        /// <summary>
        /// Read Configuration Settings From Environment
        /// </summary>
        /// <returns></returns>
        public static ConfigurationSettings ReadConfigurationSettingsFromEnvironment()
        {

            var settings = new ConfigurationSettings();
            foreach (var item in settings.GetType().GetProperties())
            {
                var value = Environment.GetEnvironmentVariable(item.Name);

                if (item.PropertyType == typeof(string))
                {
                    item.SetValue(settings, value);
                }
                else if (item.PropertyType == typeof(int))
                {
                    item.SetValue(settings, Convert.ToInt32(value));
                }
                else if (item.PropertyType == typeof(bool))
                {
                    item.SetValue(settings, Convert.ToBoolean(value));
                }
            }
            return settings;
        }
    }
}
