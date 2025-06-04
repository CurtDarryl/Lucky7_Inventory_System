using MediatR;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Queries.CategoryQueries;

public class GetCategoryByIdQuery : IRequest<GetResponse>
{
    public int Id { get; set; }
}
