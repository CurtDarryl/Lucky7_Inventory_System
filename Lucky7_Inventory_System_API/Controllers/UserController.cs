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

}
