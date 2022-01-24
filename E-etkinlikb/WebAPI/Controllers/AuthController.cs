using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Concrete;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;
        private IUserService _userService;
        private IUserOperationService _opService;

        public AuthController(IAuthService authService,IUserService userService, IUserOperationService opService)
        {
            _authService = authService;
            _userService = userService;
            _opService = opService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);

            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {

                using (ReCapContext context = new ReCapContext())
                {
                    UserOperationClaim claim = new UserOperationClaim() { OperationClaimId = 2, UserId = result.Data.UserId };
                    context.Add(claim);
                    context.SaveChanges();
                }
                return Ok(result.Data);

            }

            




         

            return BadRequest(result.Message);
        }


        [HttpPost("update")]
        public ActionResult Update(UserForUpdateDto userForRegisterDto)
        {
            var registerResult = _authService.Update(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbymail")]
        public ActionResult GetByMail(string mail)
        {
            var result = _userService.GetByMail(mail);
            return Ok(result);
        }


        [HttpGet("superuser")]
        public ActionResult SuperUser(int id)
        {
            var result = _userService.SuperUser(id);
            return Ok(result);
        }

    }
}