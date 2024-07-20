namespace BestBuy.Abstractions.Models
{
    /// <summary>
    /// User
    /// </summary>
    public class User : BaseModel
    {
        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }

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
