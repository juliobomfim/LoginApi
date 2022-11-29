using LoginApiJCBomfim.App.Abstract;
using LoginApiJCBomfim.Domain.Contracts.Repositories;
using LoginApiJCBomfim.Domain.Contracts.Services;
using LoginApiJCBomfim.Domain.Model.Input;
using Microsoft.AspNetCore.Mvc;

namespace LoginApiJCBomfim.App.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : AbstractController
    {
        private readonly IAuthService _authService;

        public AuthController(IServiceProvider serviceProvider, IAuthService authService) : base(serviceProvider)
        {
            _authService = authService;
        }

        [HttpGet("signout")]
        public async Task Get() => await _authService.SignOutAsync();

        [HttpPost("signin")]
        public async Task<IActionResult> Post([FromBody] AuthModel model, CancellationToken ct) => await ExecuteAsync(_authService.SignInAsync(model, ct), ct);

    }
}
