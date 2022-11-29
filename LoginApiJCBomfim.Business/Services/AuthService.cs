using LoginApiJCBomfim.Domain.Contracts.Repositories;
using LoginApiJCBomfim.Domain.Contracts.Services;
using LoginApiJCBomfim.Domain.Model.Input;
using LoginApiJCBomfim.Domain.Model.Output;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace LoginApiJCBomfim.Business.Services
{
    internal class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly HttpContext _httpContext;

        public AuthService(IUserRepository userRepository, HttpContext httpContext)
        {
            _userRepository = userRepository;
            _httpContext = httpContext;
        }

        public async Task<Response> SignInAsync(AuthModel model, CancellationToken ct = default)
        {
            var user = await _userRepository.GetByUserAsync(model.UserName);

            if (user is null)
                return Response.Warning($"Usuário informado não existe.");

            if (user.Any(x => x.Password != model.Password))
                return Response.Warning($"A senha informada é inválida.");

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, model.UserName) };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await AuthenticationHttpContextExtensions.SignInAsync(_httpContext, 
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity),
                new AuthenticationProperties 
                { 
                    IsPersistent = true, 
                    AllowRefresh = true, 
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10) 
                });

            return Response.Success($"Usuário logado com sucesso!");
        }
    }
}
