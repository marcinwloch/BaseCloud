using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DTO.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BaseCloud.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Deployment/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DeploymentAPIController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ILogger _logger;
        private readonly IHostingEnvironment _env;

        private readonly UserManager<ApplicationUserDTO> _userManager;
        private readonly SignInManager<ApplicationUserDTO> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IDAL<UserRolesDTO> _userRolesDAL;

        public DeploymentAPIController(IConfiguration config,
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
        public IActionResult RegisterDebug([FromBody]LoginExtendedDTO login)
        {
            if (_env.IsDevelopment())
            {
                var result = _userManager.CreateAsync(new ApplicationUserDTO()
                {
                    Email = login.Email,
                    UserName = login.Email,
                    EmailConfirmed = login.isEmailConfirmed
                }, login.Password).Result;

                if (result.Succeeded)
                    return Ok();

                return NotFound();
            }
            else
            {
                return NotFound();
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult StartupDebug()
        {
            if (_env.IsDevelopment())
            {
                var adminRole = _roleManager.FindByNameAsync("Admin").Result;
                if (adminRole == null)
                {
                    adminRole = new IdentityRole("Admin");
                    _roleManager.CreateAsync(adminRole);
                }

                var manager = _roleManager.FindByNameAsync("Manager").Result;
                if (manager == null)
                {
                    manager = new IdentityRole("Manager");
                    _roleManager.CreateAsync(manager);
                }

                var userRole = _roleManager.FindByNameAsync("User").Result;
                if (userRole == null)
                {
                    userRole = new IdentityRole("User");
                    _roleManager.CreateAsync(userRole);
                }


                var admin = _userManager.FindByEmailAsync("a@a.pl").Result;
                if (admin == null)
                {
                    var result = _userManager.CreateAsync(new ApplicationUserDTO()
                    {
                        Email = "a@a.pl",
                        UserName = "a@a.pl",
                        EmailConfirmed = true
                    }, "Admin_123!").Result;

                    if (result.Succeeded)
                    {
                        var adminCreated = _userManager.FindByEmailAsync("a@a.pl").Result;

                        var r = _userManager.AddToRoleAsync(adminCreated, "Admin").Result;

                        return Ok();
                    }
                }
                return NotFound();
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult TestAdminDebug()
        {
            return Ok("You are admin, good job bro");
        }
    }
}
