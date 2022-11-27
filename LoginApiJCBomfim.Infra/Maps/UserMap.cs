using LoginApiJCBomfim.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoginApiJCBomfim.Infra.Maps
{
    public class UserMap : EntityMap<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.Property(x => x.Username)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Password).IsRequired();

            builder.HasOne(x => x.Profile)
                .WithMany(x => x.Users);

            base.Configure(builder);
        }
    }
}
