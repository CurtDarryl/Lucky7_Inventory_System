using MediatR;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Commands.StatusCommands;

public class DeleteStatusCommand : IRequest<GetResponse>
{
    public int Id { get; set; }
}
