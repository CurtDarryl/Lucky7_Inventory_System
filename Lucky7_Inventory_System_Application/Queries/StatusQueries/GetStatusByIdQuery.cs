using MediatR;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Queries.StatusQueries;

public class GetStatusByIdQuery : IRequest<GetResponse>
{
    public int Id { get; set; }
}
