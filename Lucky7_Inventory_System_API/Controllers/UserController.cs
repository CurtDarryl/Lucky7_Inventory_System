using Lucky7_Inventory_System_Application.Commands.UserCommands;
using Lucky7_Inventory_System_Application.Queries.UserQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lucky7_Inventory_System_API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("AddUser")]
    public async Task<IActionResult> AddUser([FromQuery] CreateUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("UpdateUser")]
    public async Task<IActionResult> UpdateUser([FromQuery] UpdateUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(string userId)
    {
        var result = await _mediator.Send(new GetUserByIdQuery { UserId = userId });
        return Ok(result);
    }

    [HttpGet("GetAllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        var result = await _mediator.Send(new GetAllUsersQuery());
        return Ok(result);
    }
}