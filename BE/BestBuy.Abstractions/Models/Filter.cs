namespace BestBuy.Abstractions.Models
{
    /// <summary>
    /// Filter
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// Is Ascending Order
        /// </summary>
        public bool IsAscendingOrder { get; set; } = true;

        /// <summary>
        /// All Previous Searched
        /// </summary>
        public ICollection<string>? AllPreviousSearched { get; set; }
    }
}
