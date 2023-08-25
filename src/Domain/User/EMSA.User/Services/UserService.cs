using EMSA.Common.Extensions;
using EMSA.Core.Data;
using EMSA.User.Models;
using Microsoft.EntityFrameworkCore;

namespace EMSA.User.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Lấy thông tin token của người dùng
        /// </summary>
        /// <param name="username">Tên người dùng</param>
        /// <returns>token</returns>
        Task<UserToken?> GetUserInfoAsync(string username);

        /// <summary>
        /// Kiểm tra tài khoản của người dùng nhập hợp lệ không
        /// </summary>
        /// <param name="user">Username and Password</param>
        /// <returns>true/false</returns>
        Task<bool> IsValidUserAccountAsync(UserLogin user);
    }

    public class UserService : IUserService
    {
        private readonly ITenantDbContextFactory _tenantDbContextFactory;

        public UserService(ITenantDbContextFactory tenantDbContextFactory)
        {
            _tenantDbContextFactory = tenantDbContextFactory;
        }

        public async Task<UserToken?> GetUserInfoAsync(string username)
        {
            await using var context = _tenantDbContextFactory.CreateDbContext();
            return await context.Users.Where(x => x.Username == username).Select(x => new UserToken()
            {
                Username = x.Username,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).FirstOrDefaultAsync();
        }

        public async Task<bool> IsValidUserAccountAsync(UserLogin user)
        {
            await using var context = _tenantDbContextFactory.CreateDbContext();
            var hashed = user.Password.Hash();
            var valid = await context.Users.Where(x => x.Username == user.Username && x.Password == hashed).AnyAsync();

            return valid;
        }
    }
}