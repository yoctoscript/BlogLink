using BlogLink.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BlogLink.Repositories;
using BlogLink.Services;

namespace BlogLink.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserManager<IdentityUser> userManager;
    private readonly JwtService jwtService;
    public UsersController(UserManager<IdentityUser> userManager, JwtService jwtService)
    {
        this.userManager = userManager;
        this.jwtService = jwtService;
    }

    [Route("register")]
    [HttpPost]
    public async Task<ActionResult<User>> Register(User user)
    {   
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result0 = await userManager.FindByNameAsync(user.UserName);
        if(result0 is not null)
        {
            return new ConflictObjectResult(new {error = "Username already in use"});
        }


        var identityUser = new IdentityUser() {UserName = user.UserName};
        var result1 = await userManager.CreateAsync(
            identityUser,
            user.Password
        );

        if(!result1.Succeeded)
        {
            return BadRequest(result1.Errors);
        }
        else
        {
            await userManager.AddToRoleAsync(identityUser, Roles.Member);
        }

        user.Password = string.Concat(Enumerable.Repeat("*", user.Password.Length));
        return Created("Register", user);
    }

    [HttpGet]
    [Route("fetch")]
    public async Task<ActionResult<User>> Fetch(string username)
    {
        var user = await userManager.FindByNameAsync(username);
        if(user is null)
        {
            return NotFound();
        }
        else
        {   
            return Ok(new {Username = user.UserName});
        }
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest("Bad credentials");
        }
        var user = await userManager.FindByNameAsync(request.UserName);
        if(user is null)
        {
            return BadRequest("Bad credentials");
        } 
        var isPasswordValid = await userManager.CheckPasswordAsync(user, request.Password);
        if(!isPasswordValid)
        {
            return BadRequest("Bad credentials");
        }
        var response = jwtService.CreateToken(user);
        return Ok(response);
    }

}