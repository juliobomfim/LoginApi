using LoginApiJCBomfim.App.Abstract;
using LoginApiJCBomfim.Domain.Contracts.Repositories;
using LoginApiJCBomfim.Domain.Contracts.Services;
using LoginApiJCBomfim.Domain.Model.Input;
using Microsoft.AspNetCore.Mvc;

namespace LoginApiJCBomfimApp.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class UserController : AbstractController
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public UserController(IServiceProvider serviceProvider, IUserRepository userRepository, IUserService userService) : base (serviceProvider)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string user, CancellationToken ct) => Ok(await _userRepository.GetByUserAsync(user, ct));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserModel model, CancellationToken ct) => await ExecuteAsync(_userService.LoginRegisterAsync(model, ct), ct);
    }
}
