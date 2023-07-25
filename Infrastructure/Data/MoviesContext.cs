using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Data;
public class MoviesContext : DbContext
{
    public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
    {
        
    }
      public DbSet<Movie> ?Movies { get; set; }
      public DbSet<Genre> ?Genres { get; set; }
     public DbSet<Director> ?Directors { get; set; }
      protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
          


          
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
     
     }