using FullstackUsers.Core.Entities;
using FullstackUsers.Core.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FullstackUsers.Core.Services
{
    public class TokenService
    {
        private PrivateKeysOptions privateKeysOptions;
        public TokenService(IOptions<PrivateKeysOptions> options)
        {
            privateKeysOptions = options.Value;
        }

        public string GenerateToken(UserEntity user)
        {
            var handler = new JwtSecurityTokenHandler();

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(privateKeysOptions.TokenGenerator)),
                SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(1),
                Subject = GenerateClaims(user)
            };

            var token = handler.CreateToken(tokenDescriptor);
            var tokenStr = handler.WriteToken(token);

            return tokenStr;
        }

        private static ClaimsIdentity GenerateClaims(UserEntity user)
        {
            var identity = new ClaimsIdentity();

            identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));

            return identity;
        }
    }
}
