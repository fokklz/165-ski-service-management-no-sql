using SkiServiceAPI.Common;
using SkiServiceModels.BSON.Models;
using SkiServiceModels.DTOs;

namespace SkiServiceAPI.Interfaces
{
    public interface ITokenService
    {
        Task<TokenData> CreateToken(User user, bool keep = true);
        Task<TaskResult<RefreshResult>> RefreshToken(string token, string refreshToken);
    }
}