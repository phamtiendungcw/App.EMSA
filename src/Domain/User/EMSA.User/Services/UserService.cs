using EMSA.User.Models;

namespace EMSA.User.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Kiểm tra tài khoản của người dùng nhập hợp lệ không
        /// </summary>
        /// <param name="user">Username and Password</param>
        /// <returns>true/false</returns>
        Task<bool> IsValidUserAccountAsync(UserLogin user);

        /// <summary>
        /// Lấy thông tin token của người dùng
        /// </summary>
        /// <param name="username">Tên người dùng</param>
        /// <returns>token</returns>
        Task<UserToken> GetUserTokenInfoAsync(string username);
    }

    public class UserService : IUserService
    {
        public UserService()
        {
        }

        public Task<bool> IsValidUserAccountAsync(UserLogin user)
        {
            throw new NotImplementedException();
        }

        public Task<UserToken> GetUserTokenInfoAsync(string username)
        {
            throw new NotImplementedException();
        }
    }
}