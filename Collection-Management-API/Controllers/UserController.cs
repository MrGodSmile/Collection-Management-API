using CollectionManagementAPI.Entity;
using CollectionManagementAPI.Service.Interfeces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;

namespace Collection_Management_API.Controllers;

[ApiController]
[SwaggerTag("User")]
[Route("[controller]")]
[Authorize (Roles = "Admin")]
public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly IIdentityService _identityService;

    public UserController(IUserService userService, IIdentityService identityService)
    {
        _userService = userService;
        _identityService = identityService;
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<UserEntity>> GetById(int id) 
    {
        var user = await _userService.GetById(id);
        if (user == null)
        {
            return NotFound("User not found");
        }
        return user;
    }

    [HttpGet("")]
    public ActionResult<IQueryable<UserEntity>> GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }
    
    [HttpGet("{skip:int}/{take:int}")]
    public ActionResult<IQueryable<UserEntity>> GetRange(int skip, int take)
    {
        var users = _userService.GetRange(skip, take);
        return Ok(users);
    }
    
    [HttpPost("")]
    public async Task<ActionResult<UserEntity>> Create(RegisterModel registerModel)
    {
        UserEntity user = _userService.SearchByLogin(registerModel.UserName);
        if (user != null)
        {
            return BadRequest("This username is already in use");
        }
        
        _identityService.CreatePasswordHash(registerModel.Password, out byte[] passwordHash);

        user = new UserEntity()
        {
            PasswordHash = passwordHash,
            UserName = registerModel.UserName, 
            Email= registerModel.Email, 
            Name = registerModel?.Name, 
            Surname = registerModel?.Surname
        };
        await _userService.Create(user);
        return Ok(user);
    }
    
    [HttpPut("")]
    public async Task<ActionResult<UserEntity>> Update(UpdateModel updateModel)
    {
        var user = await _userService.GetById(updateModel.Id);
        user.UserName = updateModel.UserName;
        user.Email = updateModel.Email;
        user.Name = updateModel.Name;
        user.Surname = updateModel.Surname;
        
        await _userService.Update(user);
        return Ok(user);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<bool> Delete(int id)
    {
        return await _userService.Delete(id);
    }

    [HttpGet("{login}")]
    public ActionResult<UserEntity> SearchByLogin(string login)
    {
        var user =  _userService.SearchByLogin(login);
        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }
}