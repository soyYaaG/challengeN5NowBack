using Microsoft.EntityFrameworkCore;
using Permission.Domain.Entities;

namespace Permission.Persistence;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TipoPermisos>()
            .HasMany(e => e.Permisos)
            .WithOne(e => e.TipoPermisos)
            .HasForeignKey(e => e.TipoPermiso)
            .HasPrincipalKey(e => e.Id);
    }

    public DbSet<Permisos> Permisos { get; set; }
    public DbSet<TipoPermisos> TipoPermisos { get; set; }
}