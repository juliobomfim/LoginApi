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
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected SqliteDbContext _context;
        protected Repository(SqliteDbContext context) => _context = context;
        public void DeleteAsync(T entity) => _context.Set<T>().Remove(entity);
        public async Task InsertAsync(T entity, CancellationToken ct = default) => await _context.AddAsync(entity, ct);
        public async Task<T> GetAsync(Guid id, CancellationToken ct = default) => await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id, ct);
    }
}
