using EMSA.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMSA.Core.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "account");
            builder.Property(x => x.Username).IsRequired().HasMaxLength(250);
            builder.HasIndex(x => x.Username).IsUnique();
            builder.Property(x => x.Password).HasMaxLength(250);
            builder.Property(x => x.Email).HasMaxLength(250);
            builder.Property(x => x.FirstName).HasMaxLength(250);
            builder.Property(x => x.LastName).HasMaxLength(250);
        }
    }
}