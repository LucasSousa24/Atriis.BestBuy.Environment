namespace BestBuy.Abstractions.Models
{
    /// <summary>
    /// Base model for all classes
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Created On 
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Updated On
        /// </summary>
        public DateTime UpdatedOn { get; set; }

        /// <summary>
        /// Is Deleted
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
