﻿using Academy.AuthenticationService.Contracts;
using Academy.AuthenticationService.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Academy.AuthenticationService
{
    public class AuthManager : IAuthService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly List<User> _users;

        public AuthManager(IOptions<JwtSettings> options)
        {
             _jwtSettings = options.Value;

            _users = new List<User>() 
            { 
                new User()
                {
                    Username="Sahlar",
                    Password = "123",
                    Email = "sahlar@code.az",
                    Role = "Admin"
                },
                new User()
                {
                    Username="Yusif",
                    Password = "123",
                    Email = "yusif@code.az",
                    Role = "Member"
                }
            };
        }

        public async Task<string> CreateToken(TokenRequestModel model)
        {
            var user = _users.Find(x => x.Username == model.Username);

            if (user == null)
                throw new Exception();

            if (user.Password != model.Password)
                throw new Exception();

            var jwtSecurityToken = CreateJwtToken(user);

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        private JwtSecurityToken CreateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("roles",user.Role)
            };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddSeconds(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }
    }

    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
