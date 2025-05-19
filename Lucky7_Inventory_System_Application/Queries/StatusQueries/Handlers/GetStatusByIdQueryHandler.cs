using Lucky7_Inventory_System_Application.Constants;
using Lucky7_Inventory_System_Application.Interfaces;
using Lucky7_Inventory_System_Domain.Entities;
using MediatR;
using System.Net;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Queries.StatusQueries.Handlers;

public class GetStatusByIdQueryHandler : IRequestHandler<GetStatusByIdQuery, GetResponse>
{
    private readonly IGenericRepository<Status> _repository;

    public GetStatusByIdQueryHandler(IGenericRepository<Status> repository)
    {
        _repository = repository;
    }

    public async Task<GetResponse> Handle(GetStatusByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var status = await _repository.GetById(request.Id);
            if (status == null)
            {
                return new GetResponse(true, null, "Status not found", HttpStatusCode.NotFound);
            }

            return new GetResponse(true, status, "Status was Successfully Retrieved", HttpStatusCode.OK);
        }
        catch (Exception ex)
        {
            return new GetResponse(true, null, ex.Message, HttpStatusCode.InternalServerError);
        }
    }
}