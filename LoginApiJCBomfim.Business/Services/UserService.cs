using LoginApiJCBomfim.Domain.Contracts.Repositories;
using LoginApiJCBomfim.Domain.Contracts.Services;
using LoginApiJCBomfim.Domain.Entities;
using LoginApiJCBomfim.Domain.Model.Input;
using LoginApiJCBomfim.Domain.Model.Output;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApiJCBomfim.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IProfileRepository _profileRep;
        private readonly IUserRepository _userRep;

        public UserService(IProfileRepository profileRep, IUserRepository userRep)
        {
            _profileRep = profileRep;
            _userRep = userRep;
        }

        public async Task<Response> LoginRegisterAsync(UserModel model, CancellationToken ct = default)
        {
            if (string.IsNullOrEmpty(model.Name))
                return Response.Warning("Nome do usuário não informado!");

            if (model.Name.Length > 90)
                return Response.Warning("Nome do usuário não pode conter mais que 90 caracteres!");

            if (string.IsNullOrEmpty(model.Username))
                return Response.Warning("Login não informado!");

            if (model.Username.Length > 12)
                return Response.Warning("Login não pode conter mais que 12 caracteres!");

            var profile = await _profileRep.GetAsync(model.Profile);

            var user = new User(model.Username, model.Password, model.Name, profile) ;

            await _userRep.InsertAsync(user, ct);

            return Response.Success($"Usuário {user.Name} cadastrado com sucesso!", new { user.Id, user.Name });
        }
    }
}
