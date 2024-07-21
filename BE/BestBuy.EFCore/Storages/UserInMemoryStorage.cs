using BestBuy.Abstractions.Models;
using BestBuy.Abstractions.Storages;
using BestBuy.EFCore.Helpers;
using System.Runtime.Intrinsics.X86;

namespace BestBuy.EFCore.Storages
{
    /// <summary>
    /// In Memory Storage For Users
    /// </summary>
    public class UserInMemoryStorage : IUserStorage
    {
        private List<User> _users = new List<User> { new User
            {
                Id = 1,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                IsDeleted = false,
                Username = "user1",
                Password = "password1"
            }
        };

        /// <inheritdoc />
        public async Task<User> CreateUserAsync(User user, CancellationToken cancellationToken = default)
        {
            user.Id = Helper.IdGenerator();

            _users.Add(user);

            return await Task.FromResult(user);
        }

        /// <inheritdoc />
        public async Task DeleteUserAsync(long userId, string deletedBy, CancellationToken cancellationToken = default)
        {
            var user = _users.Where(e => e.Id == userId).FirstOrDefault();

            if (user == null)
            {
                throw new Exception("User Isn't created in the Db");
            }

            _users.Remove(user);

            await Task.CompletedTask;
        }

        /// <inheritdoc />
        public async Task<User> GetUserByCredentialsAsync(string username, string password, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(_users.FirstOrDefault(e => e.Username == username && e.Password == password));
        }

        /// <inheritdoc />
        public async Task UpdateUserAsync(User user, CancellationToken cancellationToken = default)
        {
            var existingUser = _users.Where(e => e.Id == user.Id).FirstOrDefault();

            if (existingUser == null)
            {
                throw new System.Exception("");
            }

            _users.Remove(existingUser);
            _users.Add(user);

            await Task.CompletedTask;
        }
    }
}
