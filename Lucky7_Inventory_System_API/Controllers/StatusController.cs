using Lucky7_Inventory_System_Application.Commands.StatusCommands;
using Lucky7_Inventory_System_Application.Queries.StatusQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Lucky7_Inventory_System_API.Controllers;

[ApiController]
[Route("[controller]")]
public class StatusController : Controller
{
    private readonly IMediator _mediator;

    public StatusController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("CreateStatus")]
    public async Task<IActionResult> CreateStatus([FromQuery]CreateStatusCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("UpdateStatus")]
    public async Task<IActionResult> UpdateStatus([FromQuery] UpdateStatusCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("DeleteStatus")]
    public async Task<IActionResult> DeleteStatus([FromQuery] UpdateStatusCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStatusById(int id)
    {
        var result = await _mediator.Send(new GetStatusByIdQuery { Id = id});
        return Ok(result);
    }

    [HttpGet("GetAllStatus")]
    public async Task<IActionResult> GetAllStatus()
    {
        var result = await _mediator.Send(new GetAllStatusQuery());
        return Ok(result);
    }
}
