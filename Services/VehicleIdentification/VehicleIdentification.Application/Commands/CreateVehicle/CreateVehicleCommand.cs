using System;
using MediatR;

namespace VehicleIdentification.Application.Commands.CreateVehicle;

public class CreateVehicleCommand(string licensePlate, string make, string model, int year, 
            string color, string vehicletype, string vehicleclass, string plate, string brand, string chassisnumber, 
            string renavam, string engine, string fuel, string category) : IRequest<string>
    {
        public string LicensePlate { get; set; } = licensePlate;
        public string Make { get; set; } = make;
        public string Model { get; set; } = model;
        public int Year { get; set; } = year;
        public string Color { get; set; } = color;
        public string VehicleType { get; set; } = vehicletype;
        public string VehicleClass { get; set; } = vehicleclass;
        public string Plate { get; set; } = plate;
        public string Brand { get; set; } = brand;
        public string ChassisNumber { get; set; } = chassisnumber;
        public string Renavam { get; set; } = renavam;
        public string Engine { get; set; } = engine;
        public string Fuel { get; set; } = fuel;
        public string Category { get; set; } = category;
    }

