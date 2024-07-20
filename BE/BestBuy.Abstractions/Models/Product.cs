using System.Text.Json.Serialization;

namespace BestBuy.Abstractions.Models
{
    /// <summary>
    /// Product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Sku
        /// </summary>
        [JsonPropertyName("sku")]
        public int Sku { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// SalePrice
        /// </summary>
        [JsonPropertyName("salePrice")]
        public decimal SalePrice { get; set; }

        /// <summary>
        /// ThumbnailImage
        /// </summary>
        [JsonPropertyName("thumbnailImage")]
        public string ThumbnailImage { get; set; }
    }
}
