using MediatR;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Queries.UserQueries;

public class GetUserByIdQuery : IRequest<GetResponse>
{
    public required string Id { get; set; }
}
