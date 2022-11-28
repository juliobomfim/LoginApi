using LoginApiJCBomfim.Domain.Contracts.Repositories;
using LoginApiJCBomfim.Domain.Entities;
using LoginApiJCBomfim.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApiJCBomfim.Infra.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(SqliteDbContext context) : base(context)
        {
        }

        Task<List<User>> IUserRepository.GetByUserAsync(string user, CancellationToken ct) =>
            _context.Set<User>()
            .Where(u => EF.Functions.Like(u.Username, $"%{user}"))
            .ToListAsync(ct);
    }
}
