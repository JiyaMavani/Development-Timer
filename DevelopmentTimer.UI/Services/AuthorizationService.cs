using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DevelopmentTimer.UI.Services
{
    public class AuthorizationService
    {
        private readonly IJSRuntime js;

        public AuthorizationService(IJSRuntime js)
        {
            this.js = js;
        }

        public async Task<string> GetTokenAsync()
        {
            return await js.InvokeAsync<string>("localStorage.getItem", "authToken");
        }

        public async Task<bool> IsLoggedInAsync()
        {
            var token = await GetTokenAsync();
            return !string.IsNullOrEmpty(token);
        }

        public async Task<string> GetUserRoleAsync()
        {
            var token = await GetTokenAsync();
            if (string.IsNullOrEmpty(token)) return null;

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);
            var roleClaim = jwt.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            return roleClaim?.Value;
        }

        public async Task<bool> HasRoleAsync(string requiredRole)
        {
            var role = await GetUserRoleAsync();
            return role == requiredRole;
        }
    }
}