using Lucky7_Inventory_System_Application.Constants;
using Lucky7_Inventory_System_Application.Interfaces;
using Lucky7_Inventory_System_Domain.Entities;
using MediatR;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Commands.StatusCommands.Handlers;

public class DeleteStatusCommandHandler : IRequestHandler<DeleteStatusCommand, GetResponse>
{
    private readonly IGenericRepository<Status> _repository;

    public DeleteStatusCommandHandler(IGenericRepository<Status> repository)
    {
        _repository = repository;
    }

    public async Task<GetResponse> Handle(DeleteStatusCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var status = await _repository.GetById(request.Id);

            if (status == null)
            {
                return new GetResponse(true, null, "Status not found", StatusResponse.notfound);
            }

            await _repository.Delete(status);

            return new GetResponse(true, status, "Status was Successfully Deleted", StatusResponse.success);
        }
        catch (Exception ex)
        {
            return new GetResponse(true, null, ex.Message, StatusResponse.unhandled);
        }
    }
}
