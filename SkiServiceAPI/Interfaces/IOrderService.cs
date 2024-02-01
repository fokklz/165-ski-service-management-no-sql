using MongoDB.Bson;
using SkiServiceAPI.Common;
using SkiServiceModels.BSON.DTOs.Requests;
using SkiServiceModels.BSON.DTOs.Responses;
using SkiServiceModels.BSON.Models;

namespace SkiServiceAPI.Interfaces
{
    public interface IOrderService : IBaseService<Order, OrderResponse, UpdateOrderRequest, CreateOrderRequest>
    {
        Task<TaskResult<IEnumerable<object>>> GetByPriorityAsync(ObjectId priorityId);
        Task<TaskResult<IEnumerable<object>>> GetByServiceAsync(ObjectId serviceId);
        Task<TaskResult<IEnumerable<object>>> GetByStateAsync(ObjectId stateId);
        Task<TaskResult<IEnumerable<object>>> GetByUserAsync(ObjectId userId);
    }
}