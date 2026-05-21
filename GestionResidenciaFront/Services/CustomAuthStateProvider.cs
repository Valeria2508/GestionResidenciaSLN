using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using GestionResidenciaFront.Data.Models;

namespace GestionResidenciaFront.Services
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal _anonymous = new(new ClaimsIdentity());
        private ClaimsPrincipal _currentUser;

        public CustomAuthStateProvider()
        {
            _currentUser = _anonymous;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(new AuthenticationState(_currentUser));
        }

        public void MarkUserAsAuthenticated(Usuario user)
        {
            var identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, user.UsuarioNombre ?? string.Empty),
                new Claim(ClaimTypes.Role, user.Rol ?? string.Empty)
            }, "CustomAuth");

            _currentUser = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
        }

        public void MarkUserAsLoggedOut()
        {
            _currentUser = _anonymous;
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
        }
    }
}
