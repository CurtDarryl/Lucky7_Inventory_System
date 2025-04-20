using Lucky7_Inventory_System_Application.Commands.UserCommands;
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
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut("UpdateUser")]
    public async Task<IActionResult> UpdateUser([FromQuery]UpdateUserCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}
