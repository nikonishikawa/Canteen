using Canteen.Auth;
using Canteen.Dtos;
using CanteenClassLibrary.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Canteen.AuthServices
{
    public class UserAuthenticationServices : IUserAuthenticationServices
    {
        private readonly UserManager<ApplicationIdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly CanteenContext _context;

        public UserAuthenticationServices(UserManager<ApplicationIdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            CanteenContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = context;
        }

        [AllowAnonymous]
        public async Task<string> RegisterUser(RegisterUser register)
        {
            try
            {
                var isCredentialExist = await _context.TblCredentials.FirstOrDefaultAsync(c => c.Username == register.Username);
                if (isCredentialExist != null)
                {
                    return "User already exists";
                }

                var user = new ApplicationIdentityUser
                {
                    UserName = register.Username
                };

                var result = await _userManager.CreateAsync(user, register.Password);

                if (!result.Succeeded)
                {
                    return "Error: Cannot create username / password .. Please try again";
                }

                if (!await _roleManager.RoleExistsAsync(UserRole.User))
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserRole.User));
                }

                await _userManager.AddToRoleAsync(user, UserRole.User);

                return "Success!";
            }
            catch (Exception ex)
            {
                return "Failed to create user: " + ex.Message;
            }
        }

        [Authorize(Roles = UserRole.Admin)]
        public async Task<string> RegisterAdmin(RegisterUser register)
        {
            try
            {
                var isCredentialExist = await _context.TblCredentials.FirstOrDefaultAsync(c => c.Username == register.Username);
                if (isCredentialExist != null)
                {
                    return "User already exists";
                }

                var user = new ApplicationIdentityUser
                {
                    UserName = register.Username,
                    Email = "",
                };

                var result = await _userManager.CreateAsync(user, register.Password);

                if (!result.Succeeded)
                {
                    return "Error: Cannot create Admin username/password .. please try again";
                }

                if (!await _roleManager.RoleExistsAsync(UserRole.Admin))
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserRole.Admin));
                }

                if (!await _roleManager.RoleExistsAsync(UserRole.User))
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserRole.User));
                }

                if (!await _roleManager.RoleExistsAsync(UserRole.Editor))
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserRole.Editor));
                }

                await _userManager.AddToRoleAsync(user, UserRole.Admin);

                return "Success!";
            }
            catch (Exception ex)
            {
                return "Failed to create user! error: " + ex.Message;
            }
        }

        [AllowAnonymous]
        public async Task<UserLoginDto> LoginAccount(RegisterUser login)
        {
            try
            {
                var credential = await _context.TblCredentials.FirstOrDefaultAsync(c => c.Username == login.Username && c.Password == login.Password);
                if (credential != null)
                {
                    var loginUser = await _userManager.FindByNameAsync(login.Username);
                    if (loginUser != null && await _userManager.CheckPasswordAsync(loginUser, login.Password))
                    {
                        var authClaim = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, loginUser.Id),
                            new Claim(ClaimTypes.GivenName, ""),
                            new Claim(ClaimTypes.Name, loginUser.UserName),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                        };

                        var userRoles = await _userManager.GetRolesAsync(loginUser);
                        foreach (var role in userRoles)
                        {
                            authClaim.Add(new Claim(ClaimTypes.Role, role));
                        }

                        var token = new JwtSecurityToken(
                            issuer: _configuration["JWT:ValidIssuer"],
                            audience: _configuration["JWT:ValidAudience"],
                            expires: DateTime.Now.AddMinutes(1),
                            claims: authClaim,
                            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"])), SecurityAlgorithms.HmacSha256)
                        );

                        var userInfo = new UserLoginDto
                        {
                            UserId = loginUser.Id,
                            Username = loginUser.UserName,
                            UserToken = new JwtSecurityTokenHandler().WriteToken(token)
                        };

                        return userInfo;
                    }
                }
                return new UserLoginDto();
            }
            catch (Exception ex)
            {
                return new UserLoginDto();
            }
        }
    }
}
