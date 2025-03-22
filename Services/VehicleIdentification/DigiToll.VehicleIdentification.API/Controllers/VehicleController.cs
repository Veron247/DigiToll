using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleIdentification.Application.Commands.CreateVehicle;
using VehicleIdentification.Application.Queries.GetVehicle;

namespace DigiToll.VehicleIdentification.API.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "vehicle")]
    public class VehicleController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetVehicleDetails(string vehicleNumber)
        {          
            var vehicleDetails = "vehicleNumber switch case";
            
            return Ok(vehicleDetails);
        }

        [HttpPost("register")]       
        public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleCommand command)
        {
            var vehicleId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetVehicleById), new { id = vehicleId }, vehicleId);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleById(string id)
        {
            var vehicle = await _mediator.Send(new GetVehicleByIdQuery(id));
            if (vehicle == null) return NotFound();
            return Ok(vehicle);
        }
    }
}
