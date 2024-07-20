using BestBuy.Abstractions.Models;
using System.Net.Mail;

namespace BestBuy.Abstractions.Storages
{
    /// <summary>
    /// Interface for User Storage
    /// </summary>
    public interface IUserStorage
    {
        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<User> CreateUserAsync(User user, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task UpdateUserAsync(User user, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="deletedBy"></param>
        /// <returns></returns>
        Task DeleteUserAsync(long userId, string deletedBy, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get User by Credentials
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<User> GetUserByCredentialsAsync(string username, string password, CancellationToken cancellationToken = default);
    }
}
