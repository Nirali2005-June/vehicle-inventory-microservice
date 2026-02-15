using Microsoft.EntityFrameworkCore;
using VehicleInventory.Domain.Entities;

namespace NS.VehicleInventory.Infrastructure.Data;

public class VehicleInventoryDbContext : DbContext
{
    public VehicleInventoryDbContext(
        DbContextOptions<VehicleInventoryDbContext> options)
        : base(options)
    {
    }

    public DbSet<Vehicle> Vehicles => Set<Vehicle>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(v => v.Id);

            entity.Property(v => v.VehicleCode)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(v => v.LocationId)
                  .IsRequired();

            entity.Property(v => v.VehicleType)
                  .IsRequired();

            entity.Property(v => v.Status)
                  .IsRequired();

            entity.HasIndex(v => v.VehicleCode)
                  .IsUnique();
        });
    }
}
