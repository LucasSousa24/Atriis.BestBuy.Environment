using System.Text.Json.Serialization;

namespace BestBuy.Abstractions.Models
{
    /// <summary>
    /// Filtered Products
    /// </summary>
    public class FilteredProducts
    {
        /// <summary>
        /// From
        /// </summary>
        [JsonPropertyName("from")]
        public int From { get; set; }
        /// <summary>
        /// To
        /// </summary>
        [JsonPropertyName("to")]
        public int To { get; set; }
        /// <summary>
        /// Current Page
        /// </summary>
        [JsonPropertyName("currentPage")]
        public int CurrentPage { get; set; }
        /// <summary>
        /// Total
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }
        /// <summary>
        /// Total Pages
        /// </summary>
        [JsonPropertyName("totalPages")]
        public int TotalPages { get; set; }
        /// <summary>
        /// Query Time
        /// </summary>
         [JsonPropertyName("queryTime")]
        public string QueryTime { get; set; }
        /// <summary>
        /// Total Time
        /// </summary>
         [JsonPropertyName("totalTime")]
        public string TotalTime { get; set; }
        /// <summary>
        /// Partial
        /// </summary>
         [JsonPropertyName("partial")]
        public bool Partial { get; set; }
        /// <summary>
        /// Canonical Url
        /// </summary>
         [JsonPropertyName("canonicalUrl")]
        public string CanonicalUrl { get; set; }
        /// <summary>
        /// Data
        /// </summary>
         [JsonPropertyName("products")]
        public IEnumerable<Product> Products { get; set; }
    }
}
