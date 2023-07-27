using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{ 
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("pelicula");
        builder.Property(p => p.Id).IsRequired();
        builder.Property(p => p.Tittle).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Year).IsRequired();
        builder.Property(p => p.Duration).IsRequired();

        builder.HasOne(u => u.Director)
            .WithMany(a => a.Movies)
            .HasForeignKey(u => u.Id_Director)
            .IsRequired();

        builder.HasOne(u => u.Genre)
            .WithMany(a => a.Movies)
            .HasForeignKey(u => u.Id_Genre)
            .IsRequired();


    }

}