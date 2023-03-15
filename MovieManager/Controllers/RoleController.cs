using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieManager.Services.Declaration;
using MovieManager.Services.Implementation;
using MovieManager.Utilities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieManager.Controllers
{
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly IRoleService roleService;
        private readonly IMapper mapper;
        private readonly ILogger<UserController> logger;

        public RoleController(IRoleService roleService, IMapper mapper,ILogger<UserController> logger)
        {
            this.roleService = roleService;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet("")]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await roleService.GetAll());
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
                return BadRequest();
            }
        }

    }
}

