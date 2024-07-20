namespace BestBuy.Abstractions.Resources
{
    /// <summary>
    /// Best Buy Resources
    /// </summary>
    public class BestBuyResources
    {
        /// <summary>
        /// General
        /// </summary>
        #region General
        public readonly string? CreatedOnIsRequired;
        public readonly string? UpdatedOnIsRequired;
        public readonly string? IsDeletedIsRequired;
        #endregion

        /// <summary>
        /// User
        /// </summary>
        #region User
        public readonly string? UsernameRequired;
        public readonly string? UsernameMaxLenght;
        public readonly string? PasswordRequired;
        public readonly string? PasswordMaxLenght;
        #endregion
    }
}
