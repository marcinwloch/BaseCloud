using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Identity;
using DTO.User;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using DAL;
using Microsoft.AspNetCore.Hosting;

namespace BaseCloud.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Token/[action]")]
    public class TokenAPIController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ILogger _logger;
        private readonly IHostingEnvironment _env;

        private readonly UserManager<ApplicationUserDTO> _userManager;
        private readonly SignInManager<ApplicationUserDTO> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IDAL<UserRolesDTO> _userRolesDAL;
    
        public TokenAPIController(IConfiguration config,
            IHostingEnvironment env,
            ILogger<TokenAPIController> logger,
            UserManager<ApplicationUserDTO> userManager,
            SignInManager<ApplicationUserDTO> signInManager,
            RoleManager<IdentityRole> roleManager,
            IDAL<UserRolesDTO> userRolesDAL)
        {
            _env = env;
            _config = config;
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _userRolesDAL = userRolesDAL;
            _roleManager = roleManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody]LoginDTO login)
        {
            IActionResult response = Unauthorized();
            var user = Authenticate(login);

            if (user != null)
            {
                var tokenString = BuildToken(user);
                return Ok(new { token = tokenString });
            }

            return response;
        }



        private string BuildToken(ApplicationUserDTO user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
           
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              expires: DateTime.Now.AddMinutes(int.Parse(_config["Jwt:ExpirationTime"])),
              claims: GetValidClaims(user).Result,
              signingCredentials: creds);
            

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private ApplicationUserDTO Authenticate(LoginDTO login)
        {
            ApplicationUserDTO user = _userManager.FindByEmailAsync(login.Email).Result;

            if (user == null)
                return null;

            var correctness = _signInManager.CheckPasswordSignInAsync(user, login.Password, false).Result;

            if (correctness.Succeeded)
            {
                return user;
            }

            return null;
        }

        private async Task<List<Claim>> GetValidClaims(ApplicationUserDTO user)
        {
            IdentityOptions _options = new IdentityOptions();
            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
           // new Claim(JwtRegisteredClaimNames.Jti, _jwtOptions.JtiGenerator()),
           // new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
            new Claim(_options.ClaimsIdentity.UserIdClaimType, user.Id.ToString()),
            new Claim(_options.ClaimsIdentity.UserNameClaimType, user.UserName)
        };
            var userClaims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.AddRange(userClaims);
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
                var role = await _roleManager.FindByNameAsync(userRole);
                if (role != null)
                {
                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    foreach (Claim roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    }
                }
            }
            return claims;
        }


    }
}
