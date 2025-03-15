using System;
using VehicleIdentification.Domain.Aggregates.Vehicle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VehicleIdentification.Infrastructure.EntityConfigurations;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
       
        // Primary Key
        builder.HasKey(v => v.VehicleId);
        builder.Property(v => v.VehicleId);
             
        // Properties Mapping
        builder.Property(v => v.VIN)
            .HasColumnName("VehicleIdentificationNumber")
            .HasMaxLength(17)
            .IsRequired();

        builder.Property(v => v.Make)
            .HasMaxLength(50);

        builder.Property(v => v.Model)
            .HasMaxLength(50);

        builder.Property(v => v.Year)
            .IsRequired();

         //Index
         builder.HasIndex(v => v.VIN).IsUnique();
         builder.HasIndex(v => v.VehicleId).IsUnique();

    }
}
