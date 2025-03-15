using System;
using System.ComponentModel.DataAnnotations;

namespace VehicleIdentification.Domain.Aggregates.Vehicle;

public class Vehicle
{
    [Key]
    [MaxLength(200)]
    public string VehicleId { get; set; } = string.Empty;

    [MaxLength(200)]
    public string VIN { get; set; } = string.Empty;

    [MaxLength(50)]
    public string Make { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Model { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Year { get; set; } = string.Empty;

    [MaxLength(100)]
    public string ChasisNumber { get; set; } = string.Empty;

    [MaxLength(100)]
    public string LicensePlate { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }
}
