
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
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        public ProfileRepository(SqliteDbContext context) : base(context)
        {
        }

        public Task<List<Profile>> GetByDescriptionAsync(string description, CancellationToken ct = default) =>
            _context.Set<Profile>()
            .Where(p => EF.Functions.Like(p.Description, $"%{description}"))
            .ToListAsync(ct);
    }
}
