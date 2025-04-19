using Lucky7_Inventory_System_Application.Constants;
using Lucky7_Inventory_System_Application.Interfaces;
using Lucky7_Inventory_System_Domain.Entities;
using MediatR;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Commands.RoleCommands.Handlers;

public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, GetResponse>
{
    private readonly IGenericRepository<Role> _repository;

    public UpdateRoleCommandHandler(IGenericRepository<Role> repository)
    {
        _repository = repository;
    }

    public async Task<GetResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var role = await _repository.GetById(request.Role.RoleId);
            if (role == null)
            {
                return new GetResponse(true, null, "Role not found", StatusResponse.notfound);
            }

            role.RoleName = request.Role.RoleName;
            role.StatusId = request.Role.StatusId ?? role.StatusId;

            var result = await _repository.Update(role);
            return new GetResponse(true, result, "Role was Successfully Updated", StatusResponse.success);
        }
        catch (Exception ex)
        {
            return new GetResponse(true, null, ex.Message, StatusResponse.unhandled);
        }
    }
}