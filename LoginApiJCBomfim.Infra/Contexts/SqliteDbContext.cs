using LoginApiJCBomfim.Infra.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApiJCBomfim.Infra.Contexts
{
    public class SqliteDbContext : DbContext
    {
        public SqliteDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optsBuilder)
        {
            optsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProfileMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
