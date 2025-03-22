using Authentication.API.Factory;
using Authentication.API.Models;
using DigiToll.DataStorage.EntityConfigurations.AccountManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(UserManager<ApplicationUser> _userManager, JwtFactory _jwtService) : ControllerBase
    {
        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRequest register)
        {
            var emailUsername = register.Email.Split('@')[0];
            var splitRoles = register.Role.Split(',');

            var user = new ApplicationUser
            {
                UserName = emailUsername,
                Email = register.Email,
                FullName = register.FullName,
                PasswordHash = register.Password,
                PhoneNumber = register.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, register.Password);
            
            if (result.Succeeded)
                await _userManager.AddToRolesAsync(user, splitRoles.ToList());

            if (result.Succeeded)
            {
                return Ok("User Created");
            }

            return BadRequest();
        }
    
        /// <summary>
        /// Get Bearer Access Token Via Client Credentials
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("token", Name = "GetToken")]
        public async Task<ActionResult<TokenResponse>> GetToken(AuthRequest model)
        {
            ActionResult response = Unauthorized();

            var user = await _userManager.FindByNameAsync(model.ClientId);

            if (user is { Active: true } && await _userManager.CheckPasswordAsync(user, model.ClientSecret) && model.GrantType == "client_credentials")
            {
                var token = _jwtService.BuildToken(user, (await _userManager.GetRolesAsync(user)).ToList());

                response = Ok(token);
            }
            else
                Console.WriteLine("Wrong login credentials, {@login}", model);

            return response;
        }
    }
}
