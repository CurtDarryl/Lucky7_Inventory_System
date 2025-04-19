using MediatR;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Commands.RoleCommands;

public class CreateRoleCommand : IRequest<GetResponse>
{
    public string? RoleName { get; set; }
}
