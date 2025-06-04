using MediatR;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Queries.RefCodeQueries;

public class GetRefCodeByIdQuery : IRequest<GetResponse>
{
    public int Id { get; set; }
}
