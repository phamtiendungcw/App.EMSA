using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EMSA.WebUI.Services
{
    public static class JwtAuthenticationExtension
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection service, IConfiguration configuration)
        {
            var jwtSetting = configuration.GetSection("JwtToken").Get<TokenSetting>();
            service.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer("EmsaScheme", option =>
            {
                option.RequireHttpsMetadata = false;
                option.SaveToken = true;
                option.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtSetting.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwtSetting.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.SecurityKey)),
                    ClockSkew = TimeSpan.Zero
                };
            });

            return service;
        }

    }
}
