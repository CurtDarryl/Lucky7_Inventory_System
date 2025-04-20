using MediatR;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Commands.UserCommands;

public class CreateUserCommand : IRequest<GetResponse>
{
    public string? Firstname { get; set; }  
    public string? Lastname { get; set; }
    public string? Password { get; set; }
    public int RoleId { get; set; }
    public int StatusId { get; set; }
}
