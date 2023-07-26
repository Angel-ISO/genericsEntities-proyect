using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{ 
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.ToTable("Genero");
        builder.Property(p => p.id).IsRequired();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
    }

}