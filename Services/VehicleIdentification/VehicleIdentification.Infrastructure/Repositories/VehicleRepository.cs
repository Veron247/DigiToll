using System;
using DigiToll.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using VehicleIdentification.Domain.Aggregates;
using VehicleIdentification.Domain.Aggregates.Vehicle;
using VehicleIdentification.Infrastructure.Persistence;

namespace VehicleIdentification.Infrastructure.Repositories;

public class VehicleRepository(VehicleDbContext Context) : Repository<Vehicle>(Context), IVehicleRepository
{
    public async Task<bool> VehiclePropertyExist(string propertyValue, string propertyName, string vehicleId)
    {
       var existingVehicle = await _context.Vehicles.FirstOrDefaultAsync(v => EF.Property<string>(v, propertyName) == propertyValue && v.VehicleId != vehicleId);
       return existingVehicle != null ;
    }
}
