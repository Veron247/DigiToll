using AutoMapper;
using MediatR;
using VehicleIdentification.Domain.Aggregates.Vehicle;
using VehicleIdentification.Infrastructure.Persistence;

namespace VehicleIdentification.Application.Commands.CreateVehicle;

public class CreateVehicleCommandHandler(IVehicleUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<CreateVehicleCommand, string>
{
    public async Task<string> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _unitOfWork.BeginTransactionAsync();

            var vehicleExist = await _unitOfWork.VehicleRepository.VehiclePropertyExist(request.LicensePlate, "LicensePlate", "");
            if (vehicleExist)
            {
                return "Vehicle with the same license plate already exist";
            }
            var vehicle = _mapper.Map<Vehicle>(request);
            vehicle.CreatedDate = DateTime.Now;

            _unitOfWork.VehicleRepository.Add(vehicle);
            await _unitOfWork.CommitAsync();
            
            return vehicle.VehicleId;
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackAsync();
            throw new Exception(ex.Message);
        }
    }
}