using LoginApiJCBomfim.Domain.Contracts.Repositories;
using LoginApiJCBomfim.Domain.Contracts.Services;
using LoginApiJCBomfim.Domain.Entities;
using LoginApiJCBomfim.Domain.Model.Input;
using LoginApiJCBomfim.Domain.Model.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApiJCBomfim.Business.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRep;
        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRep = profileRepository;
        }

        public async Task<Response> ProfileRegisterAsync(ProfileModel model, CancellationToken ct = default)
        {
            if (string.IsNullOrEmpty(model.Description))
                return Response.Warning("Nome do perfil não informado!");

            if (model.Description.Length > 200)
                return Response.Warning("Nome do perfil não pode conter mais que 200 caracteres.");

            var profile = new Profile(model.Description);

            await _profileRep.InsertAsync(profile);

            return Response.Success($"Perfil {profile.Description} cadastrado com sucesso!", new { profile.Id, profile.Description });
        }
    }
}
