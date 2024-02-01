using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using SkiServiceAPI.Common;
using SkiServiceAPI.Interfaces;
using SkiServiceModels.BSON.DTOs.Requests;
using SkiServiceModels.BSON.DTOs.Responses;
using SkiServiceModels.BSON.Models;

namespace SkiServiceAPI.Services
{
    public class OrderService : GenericService<Order, OrderResponse, UpdateOrderRequest, CreateOrderRequest>, IOrderService
    {
        private readonly IMongoDBContext _context;
        private readonly IMapper _mapper;

        public OrderService(IMongoDBContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, mapper, httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Orders by User
        /// </summary>
        /// <param name="userId">The target User</param>
        /// <returns>All Orders assigned to that user</returns>
        public async Task<TaskResult<IEnumerable<object>>> GetByUserAsync(ObjectId userId)
        {
            var query = await _context.Orders.FindAsync(Builders<Order>.Filter.Eq(e => e.UserId, userId));
            var filtered = ApplyFilter(query.AsQueryable());
            var orders = filtered.ToList();

            return ResolveList(orders);
        }

        /// <summary>
        /// Get all Orders by Priority
        /// </summary>
        /// <param name="priorityId">The target Priority</param>
        /// <returns>All Orders assigned to that priority</returns>
        public async Task<TaskResult<IEnumerable<object>>> GetByPriorityAsync(ObjectId priorityId)
        {
            var query = await _context.Orders.FindAsync(Builders<Order>.Filter.Eq(e => e.PriorityId, priorityId));
            var filtered = ApplyFilter(query.AsQueryable());
            var orders = filtered.ToList();

            return ResolveList(orders);
        }

        /// <summary>
        /// Get all Orders by State
        /// </summary>
        /// <param name="priorityId">The target State</param>
        /// <returns>All Orders assigned to that state</returns>
        public async Task<TaskResult<IEnumerable<object>>> GetByStateAsync(ObjectId stateId)
        {
            var query = await _context.Orders.FindAsync(Builders<Order>.Filter.Eq(e => e.StateId, stateId));
            var filtered = ApplyFilter(query.AsQueryable());
            var orders = filtered.ToList();

            return ResolveList(orders);
        }

        /// <summary>
        /// Get all Orders by State
        /// </summary>
        /// <param name="priorityId">The target Service</param>
        /// <returns>All Orders assigned to that service</returns>
        public async Task<TaskResult<IEnumerable<object>>> GetByServiceAsync(ObjectId serviceId)
        {
            var query = await _context.Orders.FindAsync(Builders<Order>.Filter.Eq(e => e.ServiceId, serviceId));
            var filtered = ApplyFilter(query.AsQueryable());
            var orders = filtered.ToList();

            return ResolveList(orders);
        }


    }
}