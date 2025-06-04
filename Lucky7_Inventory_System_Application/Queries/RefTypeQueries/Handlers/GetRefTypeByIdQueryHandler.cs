using System.Net;
using Lucky7_Inventory_System_Application.Interfaces;
using Lucky7_Inventory_System_Domain.Entities;
using MediatR;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Queries.RefTypeQueries.Handlers;

public class GetRefTypeByIdQueryHandler : IRequestHandler<GetRefTypeByIdQuery, GetResponse>
{
    private readonly IGenericRepository<RefType> _repository;

    public GetRefTypeByIdQueryHandler(IGenericRepository<RefType> repository)
    {
        _repository = repository;
    }

    public async Task<GetResponse> Handle(GetRefTypeByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var refType = await _repository.GetById(request.Id);

            if (refType == null)
            {
                return new GetResponse(true, null, "Reference Type not found", HttpStatusCode.NotFound);
            }

            return new GetResponse(true, refType, "Successfully Rerieved Reference Type", HttpStatusCode.OK);
        }
        catch (Exception ex)
        {
            return new GetResponse(true, null, ex.Message, HttpStatusCode.InternalServerError);
        }
    }
}