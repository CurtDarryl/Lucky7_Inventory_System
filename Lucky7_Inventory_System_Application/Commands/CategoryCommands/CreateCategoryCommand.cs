using MediatR;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Commands.CategoryCommands;

public class CreateCategoryCommand : IRequest<GetResponse>
{
    public string? CategoryName { get; set; }
}
