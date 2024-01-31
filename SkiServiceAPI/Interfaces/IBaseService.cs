using MongoDB.Bson;
using SkiServiceAPI.Common;
using SkiServiceAPI.Models;
using SkiServiceModels.BSON.Interfaces.Base;

namespace SkiServiceAPI.Interfaces
{
    public interface IBaseService<T, TResponse, TUpdate, TCreate>
        where T : class, IModel
        where TResponse : class
        where TUpdate : class
        where TCreate : class
    {
        bool IsOwnerOrAdmin<TModel>(TModel? item, bool allowAdmin = true)
            where TModel : class, IModel;
        Task<bool> IsOwnerOrAdmin(ObjectId id, bool allowAdmin = true);
        Task<TaskResult<IEnumerable<object>>> GetAllAsync();
        Task<TaskResult<object>> GetAsync(ObjectId id);
        Task<TaskResult<object>> CreateAsync(TCreate entity);
        Task<TaskResult<object>> UpdateAsync(ObjectId id, TUpdate entity);
        Task<TaskResult<DeleteResponse>> DeleteAsync(ObjectId id);
    }
}
