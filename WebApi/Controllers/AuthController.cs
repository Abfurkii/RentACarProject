using Business.Abstract;
using Entities.Concrete.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public IActionResult Register(MemberForRegisterDto memberForRegisterDto)
        {
            var checkMail = _authService.MemberExists(memberForRegisterDto.Email);
            if (!checkMail.Success)
            {
                return BadRequest(checkMail.Message);
            }

            var registeredMember = _authService.Register(memberForRegisterDto);
            var result = _authService.CreateAccessToken(registeredMember.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("login")]
        public IActionResult Login(MemberForLoginDto memberForLoginDto)
        {
            var loginedMember = _authService.Login(memberForLoginDto);
            if (!loginedMember.Success)
            {
                return BadRequest(loginedMember.Message);
            }

            var result = _authService.CreateAccessToken(loginedMember.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
