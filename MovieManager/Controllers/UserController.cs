using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieManager.DTOs;
using MovieManager.Entities;
using MovieManager.Services.Declaration;
using MovieManager.Services.Implementation;
using MovieManager.Utilities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieManager.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly IJwtService jwtService;
        private readonly ILogger<UserController> logger;

        public UserController(IUserService userService, IMapper mapper, IJwtService jwtService, ILogger<UserController> logger)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.jwtService = jwtService;
            this.logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginDTO loginDTO)
        {
            var user = userService.Login(loginDTO);

            if (user == null)
                return BadRequest(new { message = "Email or password is incorrect" });

            var token = jwtService.GenerateToken(user.Id);
            return Ok(new { token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterDTO registerDTO)
        {
            try
            {
                // Create user
                var user = await userService.Register(registerDTO);
                return Ok(user);
            }
            catch (Exception ex)
            {
                // Return error message if there was an exception
                logger.LogInformation(ex.Message);
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [JwtAuthorize]
        public async Task<IActionResult> Insert(UserDTO userDTO)
        {
            try
            {
                await userService.Insert(mapper.Map<User>(userDTO));
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        [JwtAuthorize]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await userService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpGet("")]
        [JwtAuthorize]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await userService.GetAll());
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
                return BadRequest();
            }
        }


        [HttpPut("{id}")]
        [JwtAuthorize]
        public async Task<IActionResult> Update(UserDTO userDTO)
        {
            try
            {
                await userService.Update(mapper.Map<User>(userDTO));
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        [JwtAuthorize]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await userService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
                return BadRequest();
            }
        }
    }
}

