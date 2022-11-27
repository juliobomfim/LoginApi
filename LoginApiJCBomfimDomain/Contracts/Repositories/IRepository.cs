using LoginApiJCBomfim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApiJCBomfim.Domain.Contracts.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        Task InsertAsync(T entity, CancellationToken ct = default);
        void DeleteAsync(T entity);
        Task<T> GetAsync(Guid id, CancellationToken ct = default);
    }
}
