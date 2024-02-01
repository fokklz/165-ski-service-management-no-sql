using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using SkiServiceAPI.Common;
using SkiServiceAPI.Interfaces;
using SkiServiceModels.BSON.DTOs.Requests;
using SkiServiceModels.BSON.DTOs.Responses;
using SkiServiceModels.BSON.Models;

namespace SkiServiceAPI.Controllers
{
    /// <summary>
    /// Basic CRUD Controller for Orders
    /// </summary>
    public class OrdersController : GenericController<Order, OrderResponse, UpdateOrderRequest, CreateOrderRequest>
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service) : base(service)
        {
            _service = service;
        }

        /// <summary>
        /// Override the Create method to not require authentication
        /// Will still show possible 401 in swagger, but will work
        /// We sadly cannot override annotations; downer
        /// </summary>
        /// <param name="entity">The Entity to create</param>
        /// <returns>The Created Entity</returns>
        [HttpPost]
        [AllowAnonymous]
        public override async Task<IActionResult> Create([FromBody] CreateOrderRequest entity)
        {
            var result = await _service.CreateAsync(entity);
            return result.IsSuccess ? Ok(result.Result) : BadRequest(result.Exception);
        }

        /// <summary>
        /// Get all Orders by User
        /// </summary>
        /// <param name="userId">The target User</param>
        /// <returns>all orders for that user</returns>
        [HttpGet("user/{userId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<OrderResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByUser(string userId)
        {
            var result = await _service.GetByUserAsync(ObjectId.Parse(userId));
            return result.IsSuccess ? Ok(result.Result) : NotFound(result.Exception);
        }

        /// <summary>
        /// Get all Orders by Priority Id
        /// </summary>
        /// <param name="priorityId">The Priority</param>
        /// <returns>all orders for that priority</returns>
        [HttpGet("priority/{priorityId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<OrderResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByPriority(string priorityId)
        {
            var result = await _service.GetByPriorityAsync(ObjectId.Parse(priorityId));
            return result.IsSuccess ? Ok(result.Result) : NotFound(result.Exception);
        }

        /// <summary>
        /// Get all Orders by State Id
        /// </summary>
        /// <param name="stateId">The Sate</param>
        /// <returns>all orders for that priority</returns>
        [HttpGet("state/{stateId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<OrderResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByState(string stateId)
        {
            var result = await _service.GetByStateAsync(ObjectId.Parse(stateId));
            return result.IsSuccess ? Ok(result.Result) : NotFound(result.Error);
        }

        /// <summary>
        /// Get all Orders by Service Id
        /// </summary>
        /// <param name="serviceId">The Service</param>
        /// <returns>all orders for that service</returns>
        [HttpGet("service/{serviceId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<OrderResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByService(string serviceId) 
        {
            var result = await _service.GetByServiceAsync(ObjectId.Parse(serviceId));
            return result.IsSuccess ? Ok(result.Result) : NotFound(result.Exception);
        }

    }
}
