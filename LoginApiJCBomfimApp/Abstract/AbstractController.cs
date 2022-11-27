using LoginApiJCBomfim.Domain.Contracts.Uow;
using LoginApiJCBomfim.Domain.Model.Output;
using Microsoft.AspNetCore.Mvc;

namespace LoginApiJCBomfim.App.Abstract
{
    public abstract class AbstractController : Controller
    {
        private readonly IUow _unityOfWork;

        public AbstractController(IServiceProvider serviceProvider)
        {
            _unityOfWork = serviceProvider.GetRequiredService<IUow>();
        }

        public async Task<IActionResult> ExecuteAsync<T>(Task<T> task, CancellationToken ct = default) where T : Response
        {
            try
            {
                var response = await task;

                if (response.Type == ResponseType.Success)
                    await _unityOfWork.CommitAsync(ct);

                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(LoginApiJCBomfim.Domain.Model.Output.Response.Failure("Ocorreu um erro interno no servidor.", new 
                {
                    ex.Message,
                    ex.StackTrace,
                    ex.InnerException
                }));
            }
        }
    }
}
