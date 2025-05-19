using Lucky7_Inventory_System_Application.Constants;
using Lucky7_Inventory_System_Application.Interfaces;
using Lucky7_Inventory_System_Domain.Entities;
using MediatR;
using System.Net;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Queries.RoleQueries.Handlers;

public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, GetResponse>
{
    private readonly IGenericRepository<Role> _repository;

    public GetRoleByIdQueryHandler(IGenericRepository<Role> repository)
    {
        _repository = repository;
    }

    public async Task<GetResponse> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
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