using LoginApiJCBomfim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApiJCBomfim.Domain.Contracts.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> GetByUserAsync(string user, CancellationToken ct = default);
    }
}
