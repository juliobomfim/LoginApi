using LoginApiJCBomfim.Domain.Contracts.Uow;
using LoginApiJCBomfim.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApiJCBomfim.Infra.Uow
{
    public class UnityOfWork : IUow
    {
        private readonly SqliteDbContext _context;
        public UnityOfWork(SqliteDbContext context) { _context = context;}
        public async Task CommitAsync(CancellationToken ct = default) => await _context.SaveChangesAsync(ct);
    }
}
