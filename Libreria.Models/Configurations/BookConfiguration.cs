using Libreria.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System.Reflection.Emit;

namespace Libreria.Models.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            //tabella
            builder.ToTable("Books");
            //chiave primaria
            builder.HasKey(x => x.id);

            //autoincremento
            builder.Property(x => x.id).ValueGeneratedOnAdd();

            //Relazione Molti a Molti Libro Cateogoria
            builder.HasMany(e => e.categories)
                .WithMany(e => e.books)
                .UsingEntity(
                    "bookCategory",
                    l => l.HasOne(typeof(Category)).WithMany().HasForeignKey("CategoryId").HasPrincipalKey(nameof(Category.id)),
                    r => r.HasOne(typeof(Book)).WithMany().HasForeignKey("BookId").HasPrincipalKey(nameof(Book.id)),
                    j => j.HasKey("BookId", "CategoryId"));



            builder.Property(x => x.relase).HasColumnName("date");
            builder.Property(x => x.title).HasColumnName("title");
            builder.Property(x => x.author).HasColumnName("author");
            builder.Property(x => x.publisher).HasColumnName("publisher");

        }
    }
}
