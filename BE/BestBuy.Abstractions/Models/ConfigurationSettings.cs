using BestBuy.Abstractions.Interfaces;

namespace BestBuy.Abstractions.Models
{
    public class ConfigurationSettings : IConfigurationSettings
    {
        /// <summary>
        /// Best Buy API Key
        /// </summary>
        public string BestBuyAPIKey { get; set; }
    }
}
