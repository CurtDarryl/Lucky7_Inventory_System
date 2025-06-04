using MediatR;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Commands.UomCommands;

public class DeleteUomCommand : IRequest<GetResponse>
{
    public int UomId { get; set; }
}
