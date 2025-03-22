using System;

namespace VehicleIdentification.Application.DTOs;

public class VehicleDTO
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string VehicleType { get; set; } = string.Empty;
    public string VehicleClass { get; set; } = string.Empty;
    public string Plate { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public int Year { get; set; }
    public string ChassisNumber { get; set; } = string.Empty;
    public string Renavam { get; set; } = string.Empty;
    public string Engine { get; set; } = string.Empty;
    public string Fuel { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Owner { get; set; } = string.Empty;
    public string OwnerDocument { get; set; } = string.Empty;
    public string OwnerDocumentType { get; set; } = string.Empty;
    public string OwnerAddress { get; set; } = string.Empty;
    public string OwnerPhone { get; set; } = string.Empty;
    public string OwnerEmail { get; set; } = string.Empty;
    public string OwnerCellPhone { get; set; } = string.Empty;
    public string OwnerComplement { get; set; } = string.Empty;
    public string OwnerNeighborhood { get; set; } = string.Empty;
    public string OwnerCity { get; set; } = string.Empty;
    public string OwnerState { get; set; } = string.Empty;
    public string OwnerZipCode { get; set; } = string.Empty;
    public string OwnerCountry { get; set; } = string.Empty;
    public string OwnerBirthDate { get; set; } = string.Empty;
    public string OwnerGender { get; set; } = string.Empty;
    public string OwnerProfession { get; set; } = string.Empty;
    public string OwnerNationality { get; set; } = string.Empty;
    public string OwnerMaritalStatus { get; set; } = string.Empty;

}
