namespace BestBuy.Abstractions.Models
{
    /// <summary>
    /// Table Filters
    /// </summary>
    public class TableFilters
    {
        /// <summary>
        /// Page At
        /// </summary>
        public int PageAt { get; set; }

        /// <summary>
        /// Name Filter
        /// </summary>
        public Filter? NameFilter { get; set; }

        /// <summary>
        /// Product Category Filter
        /// </summary>
        public Filter? ProductCategoryFilter { get; set; }
    }
}
