using Lucky7_Inventory_System_Application.Constants;
using Lucky7_Inventory_System_Application.Interfaces;
using Lucky7_Inventory_System_Domain.Entities;
using MediatR;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Queries.RoleQueries.Handlers;

public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, GetResponse>
{
    private readonly IGenericRepository<Role> _repository;

    public GetAllRolesQueryHandler(IGenericRepository<Role> repository)
    {
        _repository = repository;
    }

    public async Task<GetResponse> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var roles = await _repository.GetAll();
            if (roles == null || !roles.Any())
            {
                return new GetResponse(true, null, "No Roles were Found", StatusResponse.notfound);
            }
            return new GetResponse(true, roles, "Roles were Successfully Retrieved", StatusResponse.success);
        }
        catch (Exception ex)
        {
            return new GetResponse(false, null, ex.Message, StatusResponse.unhandled);
        }
    }
}