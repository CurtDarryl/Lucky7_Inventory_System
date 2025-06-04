using System.Net;
using Lucky7_Inventory_System_Application.Interfaces;
using Lucky7_Inventory_System_Domain.Entities;
using MediatR;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Queries.UomQueries.Handlers;

public class GetAllUomQueryHandler : IRequestHandler<GetAllUomQuery, GetResponse>
{
    private readonly IGenericRepository<Uom> _repository;

    public GetAllUomQueryHandler(IGenericRepository<Uom> repository)
    {
        _repository = repository;
    }

    public async Task<GetResponse> Handle(GetAllUomQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var uoms = await _repository.GetAll();
            if (uoms == null || !uoms.Any())
            {
                return new GetResponse(true, null, "No Unit Of Measures were Found", HttpStatusCode.NotFound);
            }
            return new GetResponse(true, uoms, "Unit Of Measures were Successfully Retrieved", HttpStatusCode.OK);
        }
        catch (Exception ex)
        {
            return new GetResponse(false, null, ex.Message, HttpStatusCode.InternalServerError);
        }
    }
}