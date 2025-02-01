using iClinic.Domain.Entities.Identities;
using iClinic.Domain.Helpers;
using System.IdentityModel.Tokens.Jwt;

namespace iClinic.Identity.Contract
{
    public interface IAuthenticationService
    {
        public Task<JwtAuthResponse> GetJwtToken(User user);
        public JwtSecurityToken ReadJwtToken(string accessToken);
        public Task<(string, DateTime?)> ValidateDetails(JwtSecurityToken jwtToken, string accessToken, string refreshTken);
        public Task<JwtAuthResponse> GetRefreshToken(User user, JwtSecurityToken jwtToken, DateTime? expiryDate, string refreshToken);
        public Task<string> ValidateToken(string accessToken);
    }
}
