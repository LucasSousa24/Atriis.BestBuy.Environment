using BestBuy.Abstractions.Models;

namespace BestBuy.Abstractions.Interfaces
{
    /// <summary>
    /// External API
    /// </summary>
    public interface IExternalAPI
    {
        /// <summary>
        /// Get All Filtered Products
        /// </summary>
        /// <param name="apiRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<FilteredProducts> GetAllFilteredProductsAsync(ApiRequest apiRequest, CancellationToken cancellationToken = default);
    }
}
