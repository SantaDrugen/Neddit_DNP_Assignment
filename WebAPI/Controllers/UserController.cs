using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserLogic userLogic;

    public UsersController(IUserLogic userLogic)
    {
        this.userLogic = userLogic;
    }
    
    
    [HttpPost]
    public async Task<ActionResult<User>> CreateUserAsync(UserCreationDto dto)
    {
        try
        {
            User created = await userLogic.CreateUserAsync(dto);
            return Created($"/users/{created.Id}", created);        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}