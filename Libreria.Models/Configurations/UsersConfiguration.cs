using Libreria.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libreria.Models.Configurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.id);
            builder.HasIndex(x => x.username).IsUnique();
            builder.Property(x => x.id).ValueGeneratedOnAdd();

            builder.Property(x => x.username).HasColumnName("username");
            builder.Property(x => x.password).HasColumnName("password");
            builder.Property(x => x.name).HasColumnName("name");
            builder.Property(x => x.surname).HasColumnName("surname");
        }
    }
}
