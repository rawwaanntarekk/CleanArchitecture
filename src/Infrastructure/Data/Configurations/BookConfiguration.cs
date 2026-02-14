using CleanArchitecture.Domain.Entities.BooksModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Data.Configurations;

internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
       builder.Property(b => b.Title)
              .IsRequired()
              .HasMaxLength(200);
    }
}
