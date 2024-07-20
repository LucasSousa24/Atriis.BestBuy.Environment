
using BestBuy.Abstractions.Interfaces;
using BestBuy.Abstractions.Models;
using System.Net.Http;
using System.Text.Json;

namespace BestBuy.ExternalAPI.Services
{
    /// <summary>
    /// External API
    /// </summary>
    public class ExternalAPI : IExternalAPI
    {
        private readonly IHttpClientFactory _httpClient;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClient"></param>
        public ExternalAPI(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Get All Filtered Products
        /// </summary>
        /// <param name="apiRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<FilteredProducts> GetAllFilteredProductsAsync(ApiRequest apiRequest, CancellationToken cancellationToken = default)
        {
            var client = _httpClient.CreateClient("httpClient");

            var response = await client.GetAsync(new Uri(apiRequest.Url), cancellationToken);

            response.EnsureSuccessStatusCode();

            var str = await response.Content.ReadAsStringAsync(cancellationToken);

            return JsonSerializer.Deserialize<FilteredProducts>(str);
        }
    }
}
