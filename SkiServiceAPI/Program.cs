
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Writers;
using SkiServiceAPI.Common;
using SkiServiceAPI.Common.Extensions;
using SkiServiceAPI.Data;
using SkiServiceAPI.Interfaces;
using SkiServiceAPI.Services;
using SkiServiceModels.BSON.AutoMapper;
using SkiServiceModels.Enums;
using System.Text;

namespace SkiServiceAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.SetupSerilog();
            builder.Services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
            });

            builder.Services.AddAutoMapperProfile();
            builder.Services.AddHttpContextAccessor();

            //Service registrations
            builder.Services.AddScoped<IMongoDBContext, MongoDBContext>();

            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<ITokenService, TokenService>();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IOrderService, OrderService>();

            builder.Services.AddScoped(typeof(GenericService<,,,>));
            //builder.Services.AddScoped(typeof(IBaseService<,,,,>), typeof(GenericService<,,,,>));

            builder.SetupCORS();
            builder.SetupAuthorization();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(AppDomain.CurrentDomain.FriendlyName);

            app.UseExceptionHandlingMiddleware();

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            SeedDatabase(app.Services).Wait();

            app.Run();
        }

        /// <summary>
        /// Parameters for TokenValidation which should be used for the Application Tokens
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns>a <see cref="TokenValidationParameters"/> instance</returns>
        public static TokenValidationParameters GetTokenValidationParameters(IConfiguration configuration)
        {
            var jwtConfig = configuration.GetSection("JWT");

            var key = jwtConfig.GetValue("Key", "PLEASE_PROVIDE_A_VALID_STRONG_LONG_AND_SECURE_TOKEN")!;
            var audience = jwtConfig.GetValue("Audience", "SkiServiceManagement API");
            var issuer = jwtConfig.GetValue("Issuer", "SkiServiceManagement API");

            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                ValidAudience = audience,
                ValidIssuer = issuer,
                ValidateIssuer = false,
                ValidateAudience = false
            };
        }

        public static async Task SeedDatabase(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedContext = scope.ServiceProvider.GetRequiredService<IMongoDBContext>();
                var scopedUserService = scope.ServiceProvider.GetRequiredService<IUserService>();

                if (!await scopedContext.Users.Any())
                {
                    await scopedUserService.CreateSeed("Superadmin", "super", RoleNames.SuperAdmin);
                    await scopedUserService.CreateSeed("Mitarbeiter 1", "m1", RoleNames.User);
                    await scopedUserService.CreateSeed("Mitarbeiter 2", "m2", RoleNames.User);
                    await scopedUserService.CreateSeed("Mitarbeiter 3", "m3", RoleNames.User);
                    await scopedUserService.CreateSeed("Mitarbeiter 4", "m4", RoleNames.User);
                    await scopedUserService.CreateSeed("Mitarbeiter 5", "m5", RoleNames.User);
                    await scopedUserService.CreateSeed("Mitarbeiter 6", "m6", RoleNames.User);
                    await scopedUserService.CreateSeed("Mitarbeiter 7", "m7", RoleNames.User);
                    await scopedUserService.CreateSeed("Mitarbeiter 8", "m8", RoleNames.User);
                    await scopedUserService.CreateSeed("Mitarbeiter 9", "m9", RoleNames.User);
                    await scopedUserService.CreateSeed("Mitarbeiter 10", "m10", RoleNames.User);
                }
            }
        }
    }
}
