using Lucky7_Inventory_System_Application.Constants;
using Lucky7_Inventory_System_Application.Interfaces;
using Lucky7_Inventory_System_Domain.Entities;
using MediatR;
using System.Net;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Commands.RoleCommands.Handlers;

public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, GetResponse>
{
    private readonly IGenericRepository<Role> _repository;

    public DeleteRoleCommandHandler(IGenericRepository<Role> repository)
    {
        _repository = repository;
    }

    public async Task<GetResponse> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var status = await _repository.GetById(request.Id);

            if (status == null)
            {
                return new GetResponse(true, null, "Role not found", HttpStatusCode.NotFound);
            }

            await _repository.Delete(status);

            return new GetResponse(true, status, "Role was Successfully Deleted", HttpStatusCode.OK);
        }
        catch (Exception ex)
        {
            return new GetResponse(true, null, ex.Message, HttpStatusCode.InternalServerError);
        }
    }
}
