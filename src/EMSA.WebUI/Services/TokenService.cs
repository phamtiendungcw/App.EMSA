using EMSA.User.Models;
using Light.GuardClauses;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EMSA.WebUI.Services
{
    public interface ITokenService
    {
        string GetToken(UserToken user, int expiryMinutes = 0);
    }

    public class TokenService : ITokenService
    {
        private readonly TokenSetting _tokenOptions;

        public TokenService(IOptions<TokenSetting> tokenOptions)
        {
            _tokenOptions = tokenOptions.Value;
            _tokenOptions.SecurityKey.MustNotBeNullOrEmpty();
            _tokenOptions.Issuer.MustNotBeNullOrEmpty();
            _tokenOptions.Audience.MustNotBeNullOrEmpty();
        }

        public string GetToken(UserToken user, int expiryMinutes = 0)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Role, "user"), // TODO: set user role
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));

            var token = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(expiryMinutes),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}