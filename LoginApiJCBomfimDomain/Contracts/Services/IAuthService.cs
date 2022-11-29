using LoginApiJCBomfim.Domain.Model.Input;
using LoginApiJCBomfim.Domain.Model.Output;

namespace LoginApiJCBomfim.Domain.Contracts.Services
{
    public interface IAuthService
    {
        Task<Response> SignInAsync(AuthModel model, CancellationToken ct = default);
        Task SignOutAsync();
    }
}
