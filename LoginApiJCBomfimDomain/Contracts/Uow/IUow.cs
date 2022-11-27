using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApiJCBomfim.Domain.Contracts.Uow
{
    public interface IUow
    {
        Task CommitAsync(CancellationToken ct = default);
    }
}
