using CollectionManagementAPI.Entity;
using CollectionManagementAPI.Service.Interfeces;
using Microsoft.AspNetCore.Mvc;

namespace Collection_Management_API.Controllers;

[ApiController]
public class UserIdentityController : Controller
{
    private readonly IIdentityService _identityService;
    private readonly IUserService _userService;

    public UserIdentityController(IIdentityService identityService, IUserService userService)
    {
        _identityService = identityService;
        _userService = userService;
    }
    
    [HttpPost("Register")]
    public async Task<ActionResult<UserEntity>> Register(RegisterModel registerModel)
    {
        UserEntity user = await _userService.SearchByLogin(registerModel.UserName);
        if (user != null)
        {
            return BadRequest("There is already such a user");
        }
        
        _identityService.CreatePasswordHash(registerModel.Password, out byte[] passwordHash);

        user = new UserEntity()
        {
            PasswordHash = passwordHash,
            UserName = registerModel.UserName, 
            Email = registerModel.Email, 
            Name = registerModel.Name, 
            Surname = registerModel.Surname,
            Role = registerModel.Role
        };

        await _userService.Create(user);
        
        return Ok(user);
    }

    [HttpPost("Login")]
    public async Task<ActionResult<string>> Login(LoginModel loginModel)
    {
        var user = await _userService.SearchByLogin(loginModel.Login);
        
        if (user.IsBlock == true)
        {
            return BadRequest("User Blocked");
        }
        else if (user == null)
        {
            return NotFound("User not found");
        }
        else if (!_identityService.VerifyPasswordHash(loginModel.Password, user.PasswordHash))
        {
            return BadRequest("Wrong password");
        }

        string token = _identityService.CreateToken(user);
        return Ok(token);
    }
}