using BestBuy.Abstractions.Endpoints;
using BestBuy.Abstractions.Models;
using BestBuy.Abstractions.Storages;
using FluentValidation;

namespace BestBuy.Core.Endpoints
{
    /// <summary>
    /// User Endpoint
    /// </summary>
    public class UserEndpoint : IUserEndpoint
    {
        //DI
        private readonly IValidator<User> _validator;
        private readonly IUserStorage _userStorage;

        public UserEndpoint(IValidator<User> validator,
             IUserStorage userStorage)
        {
            _validator = validator;
            _userStorage = userStorage;
        }

        /// <inheritdoc />
        public async Task<User> CreateUserAsync(User user, CancellationToken cancellationToken = default)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            await _validator.ValidateAndThrowAsync(user, cancellationToken);

            return await _userStorage.CreateUserAsync(user);
        }

        /// <inheritdoc />
        public async Task DeleteUserAsync(long userId, string deletedBy, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(deletedBy))
            {
                throw new ArgumentNullException(nameof(deletedBy));
            }

            await _userStorage.DeleteUserAsync(userId, deletedBy, cancellationToken);
        }

        /// <inheritdoc />
        public async Task<User> GetUserByCredentialsAsync(string username, string password, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            return await _userStorage.GetUserByCredentialsAsync(username, password, cancellationToken);
        }

        /// <inheritdoc />
        public async Task UpdateUserAsync(User user, CancellationToken cancellationToken = default)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            await _validator.ValidateAndThrowAsync(user, cancellationToken);

            await _userStorage.UpdateUserAsync(user, cancellationToken);
        }
    }
}
