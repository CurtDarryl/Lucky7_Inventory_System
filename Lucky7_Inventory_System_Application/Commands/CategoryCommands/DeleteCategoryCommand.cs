using MediatR;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Commands.CategoryCommands;

public class DeleteCategoryCommand : IRequest<GetResponse>
{
    public int CategoryId { get; set; }
}
