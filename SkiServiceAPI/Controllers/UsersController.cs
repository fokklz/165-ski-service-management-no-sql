using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using SkiServiceAPI.Common;
using SkiServiceAPI.Interfaces;
using SkiServiceModels.BSON.DTOs.Requests;
using SkiServiceModels.BSON.DTOs.Responses;
using SkiServiceModels.BSON.Models;
using SkiServiceModels.DTOs.Requests;

namespace SkiServiceAPI.Controllers
{
    /// <summary>
    /// User Controller for CRUD operations
    /// Implements the Generic Controller for Users to infer the basic CRUD operations
    /// </summary>
    public class UsersController : GenericController<User, UserResponse, UpdateUserRequest, CreateUserRequest>
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService): base(userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Allow a user to get their own information based on the submitted token
        /// </summary>
        /// <returns>UserResponse</returns>
        [HttpGet("me")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Me()
        {
            var userInfo = await _userService.GetMe();
            return userInfo.IsSuccess ? Ok(userInfo.Result) : NotFound(userInfo.Exception);
        }

        /// <summary>
        /// Revoke the refresh token of the current user
        /// </summary>
        /// <returns>Empty Success Response</returns>
        [HttpPost("revoke")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Revoke()
        {
            var result = await _userService.RevokeRefreshToken();
            return result.IsSuccess ? Ok() : BadRequest(result.Exception);
        }

        /// <summary>
        /// Refresh the login by providing a valid refresh token and a valid access token
        /// </summary>
        /// <param name="model">RefreshRequest</param>
        /// <returns>LoginResponse</returns>
        [HttpPost("refresh")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Refresh([FromBody] RefreshRequest model)
        {
            var result = await _userService.Refresh(model);
            return result.IsSuccess ? Ok(result.Result) : Unauthorized(result.Exception);
        }   


        /// <summary>
        /// Login a user and return a token along with their information
        /// </summary>
        /// <param name="model">LoginRequest</param>
        /// <returns>LoginResponse</returns>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            var result = await _userService.LoginAsync(model);
            return result.IsSuccess ? Ok(result.Result) : Unauthorized(result.Exception);
        }
        
        /// <summary>
        /// Allow others to unlock locked users
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("{id}/unlock")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Unlock(string id)
        {
            var result = await _userService.UnlockAsync(ObjectId.Parse(id));
            return result.IsSuccess ? Ok(result.Result) : BadRequest(result.Exception);
        }
    }
}
