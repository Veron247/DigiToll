using System;
using System.Runtime.CompilerServices;
using AutoMapper;
using MediatR;
using VehicleIdentification.Application.DTOs;
using VehicleIdentification.Infrastructure.Persistence;

namespace VehicleIdentification.Application.Queries.GetVehicle;

public class GetVehicleByIdQueryHandler(IVehicleUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetVehicleByIdQuery, VehicleDTO>
{
    public async Task<VehicleDTO> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
    {                                                                                                                                                                                                                                        
        var vehicle =  _unitOfWork.VehicleRepository.Get(x => x.VehicleId == request.Id);
        return _mapper.Map<VehicleDTO>(vehicle);
    }
}

