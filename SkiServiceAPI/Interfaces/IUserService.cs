using MongoDB.Bson;
using SkiServiceAPI.Common;
using SkiServiceModels.BSON.DTOs.Requests;
using SkiServiceModels.BSON.DTOs.Responses;
using SkiServiceModels.BSON.Models;
using SkiServiceModels.DTOs.Requests;
using SkiServiceModels.Enums;

namespace SkiServiceAPI.Interfaces
{
    public interface IUserService : IBaseService<User, UserResponse, UpdateUserRequest, CreateUserRequest>
    {
        Task<TaskResult<object>> GetMe();
        Task<TaskResult<LoginResponse>> LoginAsync(LoginRequest model);
        Task<TaskResult<LoginResponse>> Refresh(RefreshRequest model);
        Task<TaskResult<object>> RevokeRefreshToken();
        Task<TaskResult<object>> UnlockAsync(ObjectId id);
        new Task<TaskResult<object>> CreateAsync(CreateUserRequest entity);
        new Task<TaskResult<object>> UpdateAsync(ObjectId id, UpdateUserRequest entity);
    }
}