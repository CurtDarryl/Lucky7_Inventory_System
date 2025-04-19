using Lucky7_Inventory_System_Application.Commands.RoleCommands;
using Lucky7_Inventory_System_Application.Constants;
using Lucky7_Inventory_System_Application.Interfaces;
using Lucky7_Inventory_System_Domain.Entities;
using MediatR;
using System.Linq.Expressions;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Commands.RoleCommands.Handlers;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, GetResponse>
{
    private readonly IGenericRepository<Role> _repository;

    public CreateRoleCommandHandler(IGenericRepository<Role> repository)
    {
        _repository = repository;
    }

    public async Task<GetResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var role = new Role
            {
                RoleName = request.RoleName,
                StatusId = ConstStatus.active
            };

            Expression<Func<Role, bool>> predicate = u => u.RoleName == request.RoleName;
            var occured = await _repository.GetSingleWhere(predicate);
            if (occured != null) 
            {
                return new GetResponse(true, null, "This Role Already Exist", StatusResponse.invalidoperation);
            }

            var result = await _repository.Add(role);

            return new GetResponse(true, result, "Role was Successfully Added", StatusResponse.success);
        }
        catch (Exception ex) 
        {
            return new GetResponse(true, null, ex.Message, StatusResponse.unhandled);
        }
    }
}
