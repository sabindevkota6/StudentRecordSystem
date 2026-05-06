using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using StudentRecordSystem.Data.Entities;
using StudentRecordSystem.Dtos;
using StudentRecordSystem.Dtos.Request;
using StudentRecordSystem.Dtos.Response;
using StudentRecordSystem.Services.Interfaces;

namespace StudentRecordSystem.Services.Implementations
{
    public class AuthServices(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration config) : IAuthService
    {
        public async Task<ApiResponse<string>> RegisterUserAsync(RegisterUserDto registerUserDto)
        {
            User user = new User
            {
                FirstName = registerUserDto.FirstName,
                LastName = registerUserDto.LastName,
                Email = registerUserDto.Email,
                UserName = registerUserDto.Username,
                PhoneNumber = registerUserDto.PhoneNumber
            };

            var registerResult = await userManager.CreateAsync(user, registerUserDto.Password);

            if (registerResult.Succeeded)
            {
                return new ApiResponse<string>
                {
                    Success = true,
                    Message = "User registered successfully",
                    Data = user.Id
                };
            }

            return new ApiResponse<string>
            {
                Success = false,
                Message = "Registration failed",
                Errors = registerResult.Errors.Select(e => e.Description).ToList()
            };
        }

        public async Task<LoginResponse> LoginAsync(LoginDto loginDto)
        {
            var user = await userManager.FindByNameAsync(loginDto.Username);

            if (user == null)
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = "Invalid username or password"
                };
            }

            var result = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = "Invalid username or password"
                };
            }

            // Generate JWT token
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var userRoles = await userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));

            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new LoginResponse
            {
                Success = true,
                Message = "Login successful",
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
    }
}
