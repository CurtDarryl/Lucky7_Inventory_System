using MediatR;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Commands.RoleCommands;

public class DeleteRoleCommand : IRequest<GetResponse>
{
    public int Id { get; set; }
}
