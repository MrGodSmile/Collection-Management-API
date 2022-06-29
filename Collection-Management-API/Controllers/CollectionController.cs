using System.Security.Claims;
using Collection_Management_API.DRY;
using CollectionManagementAPI.Entity;
using CollectionManagementAPI.Entity.Models.Collections;
using CollectionManagementAPI.Entity.Transformation;
using CollectionManagementAPI.Service.Interfeces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Collection_Management_API.Controllers;

[ApiController]
[SwaggerTag("Collection")]
[Route("[controller]")]
[Authorize (Roles = "Admin , User")]

public class CollectionController : Controller
{
    private readonly ICollectionService _collectionService;
    private readonly IUserService _userService;

    public CollectionController(ICollectionService collectionService, IUserService userService)
    {
        _collectionService = collectionService;
        _userService = userService;
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<CollectionEntity>> GetById(int id) 
    {
        var collection = await _collectionService.GetById(id);
        if (collection == null)
        {
            return NotFound("Collection not found");
        }
        return collection;
    }

    [HttpGet("")]
    public ActionResult<IQueryable<CollectionEntity>> GetAll()
    {
        var collections = _collectionService.GetAll();
        return Ok(collections);
    }

    [HttpGet("{skip:int}/{take:int}")]
    public ActionResult<IQueryable<CollectionEntity>> GetRange(int skip, int take)
    {
        var collections = _collectionService.GetRange(skip, take);
        return Ok(collections);
    }

    [HttpPost("")]
    public async Task<ActionResult<CollectionEntity>> Create(CollectionModel createModel)
    {
        var user = await GetUsersFromToken.GetUserFromToken(HttpContext, _userService);
        
        var collection = new CollectionEntity()
        {
            Name = createModel.Name, 
            Description= createModel.Description,
            Topic = createModel.Topic,
            UserId = user.Id
        };
        
        await _collectionService.Create(collection);
        return Ok(collection.ToCollectionModel());
    }
    
    [HttpPut("")]
    public async Task<ActionResult<UserEntity>> Update(CollectionModel collectionModel)
    {
        var user = await GetUsersFromToken.GetUserFromToken(HttpContext, _userService);

        var collection = await _collectionService.GetById(collectionModel.Id);
        
        if (user.Id != collection.UserId && user.Role != Roles.Admin)
        {
            return BadRequest("This is not your collection");
        }
        
        await _collectionService.Update(collection, collectionModel);
        
        return Ok(collection.ToCollectionModel());
    }
    
    [HttpDelete("{id:int}")]
    public async Task<bool> Delete(int id)
    {
        return await _collectionService.Delete(id);
    }

    [HttpGet("{name}")]
    public async Task<ActionResult<CollectionEntity>> SearchByName(string name)
    {
        var collection = await _collectionService.SearchByName(name);
        if (collection == null)
        {
            return NotFound();
        }

        return Ok(collection);
    }
}