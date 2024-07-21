namespace BestBuy.Abstractions.Constants
{
    /// <summary>
    /// Constants External API
    /// </summary>
    public static class ConstantsExternalAPI
    {
        /// <summary>
        /// Partial Url
        /// </summary>
        public static string PartialUrl = "https://api.bestbuy.com/v1/";
        /// <summary>
        /// Url filter Standart
        /// </summary>
        public static string UrlfilterStandart = "products?format=json&";
        /// <summary>
        /// Url Static Values
        /// </summary>
        public static string UrlStaticValues = "show=sku,name,salePrice,thumbnailImage&pageSize=12&page=";
        /// <summary>
        /// Api Key
        /// </summary>
        public static string ApiKey = "apiKey=";
    }
}
