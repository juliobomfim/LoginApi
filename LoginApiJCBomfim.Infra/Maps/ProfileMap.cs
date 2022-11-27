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
    public class ProfileMap : EntityMap<Profile>
    {
        public override void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("Profile");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasMany(x => x.Users)
                .WithOne(x => x.Profile);

            base.Configure(builder);
        }
    }
}
