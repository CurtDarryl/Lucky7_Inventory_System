using MediatR;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Queries.UomQueries;

public class GetUomByIdQuery : IRequest<GetResponse>
{
    public int Id { get; set; }
}
