using AutoMapper;
using SkiServiceAPI.Common;
using SkiServiceAPI.Common.Enums;
using SkiServiceAPI.Interfaces;
using SkiServiceModels.BSON.DTOs.Responses;
using SkiServiceModels.DTOs.Requests;
using SkiServiceModels.DTOs.Responses;
using SkiServiceModels.Models.BSON;

namespace SkiServiceAPI.Services
{
    public class UserService : GenericService<User, UserResponse, UserResponseAdmin, UpdateUserRequest, CreateUserRequest>
    {
        private readonly IMongoDBContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;

        public UserService(IMongoDBContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor, IAuthService authService, ITokenService tokenService) : base(context, mapper, httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _authService = authService;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Login a User with the given Credentials
        /// </summary>
        /// <param name="model">The Credentials of the user</param>
        /// <returns>a login Response with all information of the loggedin user as well as a token</returns>
        public async Task<TaskResult<LoginResponse>> LoginAsync(LoginRequest model)
        {
            var result = await _authService.VerifyPasswordAsync(model.Username, model.Password);
            if (!result.IsSuccess) return CreateTaskResult.Error<LoginResponse>(result);

            var user = result.Result;
            var token = await _tokenService.CreateToken(user, model.RememberMe);

            return CreateTaskResult.Success(new LoginResponse()
            {
                Id = user.Id,
                Username = user.Username,
                Locked = user.Locked,
                Role = user.Role,
                Auth = token
            });
        }
    }
}
