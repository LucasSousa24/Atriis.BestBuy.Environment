using BestBuy.Abstractions.Constants;
using BestBuy.Abstractions.Endpoints;
using BestBuy.Abstractions.Interfaces;
using BestBuy.Abstractions.Models;
using System;

namespace BestBuy.Core.Endpoints
{
    /// <summary>
    /// Product Endpoint
    /// </summary>
    public class ProductEndpoint : IProductEndpoint
    {
        private readonly IExternalAPI _externalAPI;
        private readonly IConfigurationSettings _settings;

        /// <summary>
        /// Product Endpoint
        /// </summary>
        /// <param name="externalAPI"></param>
        public ProductEndpoint(IExternalAPI externalAPI, IConfigurationSettings settings)
        {
            _externalAPI = externalAPI;
            _settings = settings;
        }

        /// <inheritdoc/>
        public async Task<FilteredProducts> GetAllFilteredProductsAsync(TableFilters filters, CancellationToken cancellationToken = default)
        {
            ApiRequest apiRequest;
            if (filters.NameFilter == null && filters.ProductCategoryFilter == null)
            {
                apiRequest = new ApiRequest { Url = $"{ConstantsExternalAPI.PartialUrl}{ConstantsExternalAPI.UrlfilterStandart}{ConstantsExternalAPI.UrlStaticValues}{filters.PageAt}&{ConstantsExternalAPI.ApiKey}{_settings.BestBuyAPIKey}" };
            } else if (filters.NameFilter != null && filters.ProductCategoryFilter == null)
            {
                string sortName = filters.NameFilter.IsAscendingOrder ? "sort=name.asc" : "sort=name.dsc";
                string queryNameString = string.Join("&", filters.NameFilter.AllPreviousSearched!.Select(value => $"name={Uri.EscapeDataString(value)}"));

                apiRequest = new ApiRequest { Url = $"{ConstantsExternalAPI.PartialUrl}products({queryNameString})?format=json&{ConstantsExternalAPI.UrlStaticValues}{filters.PageAt}&{sortName}&{ConstantsExternalAPI.ApiKey}{_settings.BestBuyAPIKey}" };
            } else if (filters.NameFilter == null && filters.ProductCategoryFilter != null)
            {
                string sortCategory = filters.ProductCategoryFilter.IsAscendingOrder ? "sort=categoryPath.name.asc" : "sort=categoryPath.name.dsc";
                string queryCategoryString = string.Join("&", filters.ProductCategoryFilter.AllPreviousSearched!.Select(value => $"categoryPath.name={Uri.EscapeDataString(value)}"));

                apiRequest = new ApiRequest { Url = $"{ConstantsExternalAPI.PartialUrl}products({queryCategoryString})?format=json&{ConstantsExternalAPI.UrlStaticValues}{filters.PageAt}&{sortCategory}&{ConstantsExternalAPI.ApiKey}{_settings.BestBuyAPIKey}" };
            } else
            {
                string sortCategory = filters.ProductCategoryFilter!.IsAscendingOrder ? "sort=categoryPath.name.asc" : "sort=categoryPath.name.dsc";
                string queryCategoryString = string.Join("&", filters.ProductCategoryFilter!.AllPreviousSearched!.Select(value => $"categoryPath.name={Uri.EscapeDataString(value)}"));

                string sortName = filters.NameFilter!.IsAscendingOrder ? "sort=name.asc" : "sort=name.dsc";
                string queryNameString = string.Join("&", filters.NameFilter!.AllPreviousSearched!.Select(value => $"name={Uri.EscapeDataString(value)}"));

                apiRequest = new ApiRequest { Url = $"{ConstantsExternalAPI.PartialUrl}products({queryCategoryString}&{queryNameString})?format=json&{ConstantsExternalAPI.UrlStaticValues}{filters.PageAt}&{sortCategory}&{sortName}&{ConstantsExternalAPI.ApiKey}{_settings.BestBuyAPIKey}" };
            }

            return await _externalAPI.GetAllFilteredProductsAsync(apiRequest);
        }
    }
}
