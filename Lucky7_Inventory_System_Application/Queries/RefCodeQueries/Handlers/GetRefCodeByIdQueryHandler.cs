using System.Net;
using Lucky7_Inventory_System_Application.Interfaces;
using Lucky7_Inventory_System_Domain.Entities;
using MediatR;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Queries.RefCodeQueries.Handlers;

public class GetRefCodeByIdQueryHandler : IRequestHandler<GetRefCodeByIdQuery, GetResponse>
{
    private readonly IGenericRepository<RefCode> _repository;

    public GetRefCodeByIdQueryHandler(IGenericRepository<RefCode> repository)
    {
        _repository = repository;
    }

    public async Task<GetResponse> Handle(GetRefCodeByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var refCode = await _repository.GetById(request.Id);

            if (refCode == null)
            {
                return new GetResponse(true, null, "Reference Code not found", HttpStatusCode.NotFound);
            }

            return new GetResponse(true, refCode, "Successfully Rerieved Reference Code", HttpStatusCode.OK);
        }
        catch (Exception ex)
        {
            return new GetResponse(true, null, ex.Message, HttpStatusCode.InternalServerError);
        }
    }
}