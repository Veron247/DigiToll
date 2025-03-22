using System;
using AutoMapper;
using VehicleIdentification.Application.Commands.CreateVehicle;
using VehicleIdentification.Application.DTOs;
using VehicleIdentification.Domain.Aggregates.Vehicle;

namespace VehicleIdentification.Application.Mappers;

public class VehicleProfile : Profile
{
    public VehicleProfile()
    {
        CreateMap<CreateVehicleCommand, Vehicle>();
        CreateMap<Vehicle, VehicleDTO>();          
    }
}
