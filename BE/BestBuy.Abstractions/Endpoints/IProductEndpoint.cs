using BestBuy.Abstractions.Models;

namespace BestBuy.Abstractions.Endpoints
{
    /// <summary>
    /// Interface for Product Endpoint
    /// </summary>
    public interface IProductEndpoint
    {
        /// <summary>
        /// Get All Filtered Products
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<FilteredProducts> GetAllFilteredProductsAsync(TableFilters filters, CancellationToken cancellationToken = default);
    }
}
