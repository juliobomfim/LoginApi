using LoginApiJCBomfim.App.Abstract;
using LoginApiJCBomfim.Domain.Contracts.Repositories;
using LoginApiJCBomfim.Domain.Contracts.Services;
using LoginApiJCBomfim.Domain.Model.Input;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginApiJCBomfim.App.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class ProfileController : AbstractController
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IProfileService _profileService;

        public ProfileController(IServiceProvider serviceProvider, IProfileRepository profileRepository, IProfileService profileService) : base(serviceProvider)
        {
            _profileRepository = profileRepository;
            _profileService = profileService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string description, CancellationToken ct) => Ok(await _profileRepository.GetByDescriptionAsync(description, ct));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProfileModel model, CancellationToken ct) => await ExecuteAsync(_profileService.ProfileRegisterAsync(model, ct), ct);


    }
}
