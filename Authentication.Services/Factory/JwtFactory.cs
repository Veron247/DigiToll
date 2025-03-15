using System;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using DigiToll.DataStorage.EntityConfigurations.AccountManagement;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Authentication.Services.Factory;

    public class JwtFactory(IConfiguration _config)
    {      
        public TokenResponse BuildToken(ApplicationUser user, string role)
        {
            var claims = new List<Claim>
            {
                 new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                 new Claim(JwtRegisteredClaimNames.Jti,  Guid.NewGuid().ToString()),
                 new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.Now).ToString(), ClaimValueTypes.Integer64),
                 new Claim(ClaimTypes.Sid, user.Id),
                 new Claim(ClaimTypes.Name, user.UserName),
                 new Claim(ClaimTypes.Role, role),
                 new Claim("DigiTollAuthenticationAPI","DigiTollAuthenticationAPI")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(_config.GetValue<int>("Jwt:TokenExpiryMinutes")),
                signingCredentials: creds);

            int durationInSeconds = (int)TimeSpan.FromMinutes(_config.GetValue<int>("Jwt:TokenExpiryMinutes")).TotalSeconds;

            return new TokenResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresIn = durationInSeconds,
                TokenType = "Bearer"
            };
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - DateTimeOffset.UnixEpoch).TotalSeconds);
    }

    public class TokenResponse
    {
        /// <summary>
        /// Access Token for authentication Request
        /// </summary>
        [JsonPropertyName("access_token")]
        public string Token { get; set; }

        /// <summary>
        /// Type of Token (typically "Bearer")
        /// </summary>
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        ///Valid duration of token after which token is invalid (in seconds)
        /// </summary>
        [JsonPropertyName("expires_in")]
        public double ExpiresIn { get; set; }
    }

    public class AuthRequest
    {
        /// <summary>
        /// Your application's Client ID. 
        /// </summary>
        [Required]
        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// Your application's Client Secret. 
        /// </summary>
        [Required]
        [JsonPropertyName("client_secret")]
        public string ClientSecret { get; set; }

        /// <summary>
        /// This must be client_credentials
        /// </summary>
        [Required]
        [JsonPropertyName("grant_type")]
        public string GrantType { get; set; }
    }
