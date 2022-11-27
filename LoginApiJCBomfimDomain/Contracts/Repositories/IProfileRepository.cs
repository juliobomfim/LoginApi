using LoginApiJCBomfim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApiJCBomfim.Domain.Contracts.Repositories
{
    public interface IProfileRepository : IRepository<Profile>
    {
        Task<List<Profile>> GetByDescriptionAsync(string description, CancellationToken ct = default);
    }
}
