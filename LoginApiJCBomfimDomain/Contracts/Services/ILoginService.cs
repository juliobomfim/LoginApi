using LoginApiJCBomfim.Domain.Model.Input;
using LoginApiJCBomfim.Domain.Model.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApiJCBomfim.Domain.Contracts.Services
{
    public interface ILoginService
    {
        Task<Response> LoginRegisterAsync(UserModel login, CancellationToken ct = default);
    }
}
