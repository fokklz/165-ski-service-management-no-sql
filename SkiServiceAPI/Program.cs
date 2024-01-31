
using Microsoft.IdentityModel.Tokens;
using SkiServiceAPI.Common;
using SkiServiceAPI.Common.Extensions;
using SkiServiceAPI.Data;
using SkiServiceAPI.Interfaces;
using SkiServiceAPI.Services;
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

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddHttpContextAccessor();

            //Service registrations
            builder.Services.AddScoped<IMongoDBContext, MongoDBContext>();

            builder.Services.AddScoped<ITokenService, TokenService>();

            builder.Services.AddScoped(typeof(GenericService<,,,,>));
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

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();


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
    }
}
