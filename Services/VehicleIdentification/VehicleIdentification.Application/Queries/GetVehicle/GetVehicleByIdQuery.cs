using System;
using MediatR;
using VehicleIdentification.Application.DTOs;

namespace VehicleIdentification.Application.Queries.GetVehicle;

public class GetVehicleByIdQuery : IRequest<VehicleDTO>
{
	public string Id { get; }

	public GetVehicleByIdQuery(string id)
	{
		Id = id;
	}
}

