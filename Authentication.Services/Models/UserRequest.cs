using System;

namespace Authentication.Services.Models;

public class UserRequest
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public bool Active { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string Role { get; set; }
}
