using System.Net;
using Lucky7_Inventory_System_Application.Interfaces;
using Lucky7_Inventory_System_Domain.Entities;
using MediatR;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Queries.UomQueries.Handlers;

public class GetUomByIdQueryHandler : IRequestHandler<GetUomByIdQuery, GetResponse>
{
    private readonly IGenericRepository<Uom> _repository;

    public GetUomByIdQueryHandler(IGenericRepository<Uom> repository)
    {
        _repository = repository;
    }

    public async Task<GetResponse> Handle(GetUomByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var role = await _repository.GetById(request.Id);
            if (role == null)
            {
                return new GetResponse(true, null, "Role not found", HttpStatusCode.NotFound);
            }

            return new GetResponse(true, role, "Successfully Rerieved Role", HttpStatusCode.OK);
        }
        catch (Exception ex)
        {
            return new GetResponse(true, null, ex.Message, HttpStatusCode.InternalServerError);
        }
    }
}