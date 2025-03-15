using System;
using Microsoft.EntityFrameworkCore;
using VehicleIdentification.Domain.Aggregates.Vehicle;
using VehicleIdentification.Infrastructure.EntityConfigurations;

namespace VehicleIdentification.Infrastructure.Persistence;



public class VehicleDbContext : DbContext
{
    public VehicleDbContext(DbContextOptions<VehicleDbContext> options)
        : base(options)
    {
    }

    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure entity properties and relationships here
        modelBuilder.ApplyConfiguration(new VehicleConfiguration());
    }
}
