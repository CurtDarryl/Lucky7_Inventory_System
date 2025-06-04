using System.Net;
using Lucky7_Inventory_System_Application.Interfaces;
using Lucky7_Inventory_System_Domain.Entities;
using MediatR;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Queries.RefTypeQueries.Handlers;

public class GetAllRefTypeQueryHanlder : IRequestHandler<GetAllRefTypeQuery, GetResponse>
{
    private readonly IGenericRepository<RefType> _repository;

    public GetAllRefTypeQueryHanlder(IGenericRepository<RefType> repository)
    {
        _repository = repository;
    }

    public async Task<GetResponse> Handle(GetAllRefTypeQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var refTypes = await _repository.GetAll();

            if (refTypes == null || !refTypes.Any())
            {
                return new GetResponse(true, null, "No Reference Types were Found", HttpStatusCode.NotFound);
            }

            return new GetResponse(true, refTypes, "Reference Types were Successfully Retrieved", HttpStatusCode.OK);
        }
        catch (Exception ex)
        {
            return new GetResponse(false, null, ex.Message, HttpStatusCode.InternalServerError);
        }
    }
}