using System;
using DigiToll.SharedKernel.Interfaces;

namespace VehicleIdentification.Domain.Aggregates;

public interface IVehicleRepository : IRepository<Vehicle.Vehicle>
{
    Task<bool> VehiclePropertyExist(string propertyValue, string propertyName, string vehicleId);
}
