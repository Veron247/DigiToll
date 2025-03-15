using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigiToll.VehicleIdentification.API.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetVehicleDetails(string vehicleNumber)
        {          
            var vehicleDetails = "vehicleNumber switch case";
            
           
            return Ok(vehicleDetails);
        }
    }
}
