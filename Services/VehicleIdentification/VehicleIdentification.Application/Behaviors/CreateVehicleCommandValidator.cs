using System;
using FluentValidation;
using VehicleIdentification.Application.Commands.CreateVehicle;

namespace VehicleIdentification.Application.Behaviors;

public class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
{
    public CreateVehicleCommandValidator()
    {
        RuleFor(x => x.LicensePlate).NotEmpty().MaximumLength(100);
        RuleFor(x => x.ChassisNumber).NotEmpty().MaximumLength(100);
        RuleFor(x => x.VehicleType).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Model).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Make).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Year).GreaterThan(0);
        RuleFor(x => x.Color).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Category).NotEmpty().MaximumLength(100);
        RuleFor(x => x.VehicleClass).NotEmpty().MaximumLength(100);
    }
}
