﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using SkiServiceAPI.Interfaces;
using SkiServiceModels.BSON.Interfaces.Base;
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
    public class GenericController<T, TResponse, TUpdate, TCreate> : ControllerBase
        where T : class, IModel
        where TResponse : class, IResponseDTO
        where TUpdate : class, IUpdateDTO
        where TCreate : class, ICreateDTO
    {

        private readonly IBaseService<T, TResponse, TUpdate, TCreate> _service;

        public GenericController(IBaseService<T, TResponse, TUpdate, TCreate> service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>TDestination mapped from T</returns>
        [HttpGet]
        [Authorize]
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
        [Authorize]
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
        [Authorize]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public virtual async Task<IActionResult> Update(string id, [FromBody] TUpdate entity)
        {
            if(!await _service.IsOwnerOrAdmin(ObjectId.Parse(id))) return Forbid();
            var result = await _service.UpdateAsync(ObjectId.Parse(id), entity);
            return result.IsSuccess ? Ok(result.Result) : NotFound(result.Error);
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>TDestination mapped from T</returns>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public virtual async Task<IActionResult> Delete(string id)
        {
            if (!await _service.IsOwnerOrAdmin(ObjectId.Parse(id))) return Forbid();
            var result = await _service.DeleteAsync(ObjectId.Parse(id));
            return result.IsSuccess ? Ok(result.Result) : NotFound(result.Error);
        }
    }
}
