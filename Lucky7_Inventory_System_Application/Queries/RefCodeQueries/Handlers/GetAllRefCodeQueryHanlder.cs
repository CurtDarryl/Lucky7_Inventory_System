using System.Net;
using Lucky7_Inventory_System_Application.Interfaces;
using Lucky7_Inventory_System_Domain.Entities;
using MediatR;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Queries.RefCodeQueries.Handlers;

public class GetAllRefCodeQueryHanlder : IRequestHandler<GetAllRefCodeQuery, GetResponse>
{
    private readonly IGenericRepository<RefCode> _repository;

    public GetAllRefCodeQueryHanlder(IGenericRepository<RefCode> repository)
    {
        _repository = repository;
    }

    public async Task<GetResponse> Handle(GetAllRefCodeQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var refCodes = await _repository.GetAll();

            if (refCodes == null || !refCodes.Any())
            {
                return new GetResponse(true, null, "No Reference Codes were Found", HttpStatusCode.NotFound);
            }

            return new GetResponse(true, refCodes, "Reference Codes were Successfully Retrieved", HttpStatusCode.OK);
        }
        catch (Exception ex)
        {
            return new GetResponse(false, null, ex.Message, HttpStatusCode.InternalServerError);
        }
    }
}