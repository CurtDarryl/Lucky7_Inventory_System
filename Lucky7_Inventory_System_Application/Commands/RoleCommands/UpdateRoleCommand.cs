using Lucky7_Inventory_System_Domain.Entities;
using MediatR;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Commands.RoleCommands;

public class UpdateRoleCommand : IRequest<GetResponse>
{
    public Role? Role { get; set; }
}
