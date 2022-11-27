using LoginApiJCBomfim.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApiJCBomfim.Infra.Maps
{
    public class EntityMap<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Created)
                   .IsRequired();
            builder.Property(e => e.Changed)
                   .IsRequired();
        }
    }
}
