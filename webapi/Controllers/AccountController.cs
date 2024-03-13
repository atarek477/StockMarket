﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.dto;
using webapi.interfaces;
using webapi.model;

namespace webapi.Controllers
{

    [ApiController]
    [Route("api/commend")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager; 


        public AccountController(UserManager<AppUser> userManager,ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;   
            _signInManager = signInManager;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginDto loginDto)
        { 
            if(!ModelState.IsValid) { return BadRequest(ModelState); }


            var user= await _userManager.Users.FirstOrDefaultAsync(x=>x.UserName== loginDto.UserName);
            if (user == null) { return Unauthorized("Invalid Username "); }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if(!result.Succeeded) { return Unauthorized("password or username wrong "); }


            return Ok(new NewUserDto { 
             UserName= user.UserName,
             Email= user.Email,
             Token= _tokenService.CreateToken(user)
            
            });
        
        
        
        }




            [HttpPost("register")]
        public async Task<IActionResult> Resgister([FromBody] RegisterDto registerDto) {

            try {
            if(!ModelState.IsValid)
                { 
                    return BadRequest(ModelState); 
                
                }
                var appUser = new AppUser
                {
                    UserName = registerDto.username,
                    Email = registerDto.email,

                };
                var CreateUser = await _userManager.CreateAsync(appUser, registerDto.password);
                if (CreateUser.Succeeded)
                {
                    var UserRole = await _userManager.AddToRoleAsync(appUser, "USER");
                    if (UserRole.Succeeded)
                    {
                        return Ok(
                            new NewUserDto { 
                            
                            UserName= appUser.UserName,
                            Email= appUser.Email,
                            Token=_tokenService.CreateToken(appUser)
                            
                            }
                            
                            
                            );
                    }
                    else
                    {
                        return StatusCode(500, UserRole.Errors);

                    }


                }
                else {

                    return StatusCode(500, CreateUser.Errors);

                }

            
            } catch (Exception e) {

                return StatusCode(500, e);
            }
        
        }

    }
}
