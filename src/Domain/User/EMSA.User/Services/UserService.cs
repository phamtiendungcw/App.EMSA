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
    }
}