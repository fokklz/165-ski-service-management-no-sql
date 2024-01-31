using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using SkiServiceAPI.Interfaces;
using SkiServiceModels.Enums;
using SkiServiceModels.Interfaces;

namespace SkiServiceAPI.Common
{
    /// <summary>
    /// Generic Controller for CRUD operations
    /// </summary>
    /// <typeparam name="T">Model</typeparam>
    /// <typeparam name="TResponse">Response DTO</typeparam>
    /// <typeparam name="TUpdate">Update DTO</typeparam>
    /// <typeparam name="TCreate">Create DTO</typeparam>
    [ApiController]
    [Route("api/[controller]")]
    public class GenericController<T, TResponseBase, TResponseAdmin, TUpdate, TCreate> : ControllerBase
        where T : class, IGenericBSONModel
        where TResponseBase : class
        where TResponseAdmin : class, TResponseBase
        where TUpdate : class
        where TCreate : class
    {

        private readonly IBaseService<T, TResponseBase, TResponseAdmin, TUpdate, TCreate> _service;

        public GenericController(IBaseService<T, TResponseBase, TResponseAdmin, TUpdate, TCreate> service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>TDestination mapped from T</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return result.IsSuccess ? Ok(result.Result) : BadRequest(result.Error);
        }

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>TDestination mapped from T</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Get(string id)
        {
            var result = await _service.GetAsync(ObjectId.Parse(id));
            return result.IsSuccess ? Ok(result.Result) : NotFound(result.Error);
        }

        /// <summary>
        /// Create entity
        /// </summary>
        /// <param name="entity">Entity Data</param>
        /// <returns>TDestination mapped from T</returns>
        [HttpPost]
        [Authorize(Roles = nameof(RoleNames.SuperAdmin))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> Create([FromBody] TCreate entity)
        {
            var result = await _service.CreateAsync(entity);
            return result.IsSuccess ? Ok(result.Result) : BadRequest(result.Error);
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity Data</param>
        /// <returns>TDestination mapped from T</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = nameof(RoleNames.SuperAdmin))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Update(string id, [FromBody] TUpdate entity)
        {
            var result = await _service.UpdateAsync(ObjectId.Parse(id), entity);
            return result.IsSuccess ? Ok(result.Result) : NotFound(result.Error);
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>TDestination mapped from T</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = nameof(RoleNames.SuperAdmin))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Delete(string id)
        {
            var result = await _service.DeleteAsync(ObjectId.Parse(id));
            return result.IsSuccess ? Ok(result.Result) : NotFound(result.Error);
        }
    }
}
