using SkiServiceAPI.Common;
using SkiServiceModels.BSON.Models;

namespace SkiServiceAPI.Interfaces
{
    public interface IAuthService
    {
        Task<TaskResult<User>> VerifyPasswordAsync(string username, string password);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
    }
}