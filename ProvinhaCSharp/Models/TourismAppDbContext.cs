using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProvinhaCSharp.Models;

public class TourismAppDbContext(DbContextOptions<TourismAppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Tour> Tours => Set<Tour>();
    public DbSet<Attractions> Attractions => Set<Attractions>();

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Tour>()
          .HasOne(t => t.User)
          .WithMany(u => u.Tours)
          .HasForeignKey(t => t.UserID)
          .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Attractions>()
          .HasMany(a => a.Tours)
          .WithMany(t => t.Attractions);

    }

}

public class TourismAppDbContextFactory : IDesignTimeDbContextFactory<TourismAppDbContext>
{
    public TourismAppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TourismAppDbContext>();

        // Pega a connection string da variável de ambiente
        var connectionString = Environment.GetEnvironmentVariable("SQL_CONNECTION");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("A variável de ambiente 'TOURISMAPP_CONNECTION_STRING' não foi definida.");
        }

        optionsBuilder.UseSqlServer(connectionString); // ou UseNpgsql, UseSqlite, etc., conforme o seu banco

        return new TourismAppDbContext(optionsBuilder.Options);
    }
}
