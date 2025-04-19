using Lucky7_Inventory_System_Application.Constants;
using Lucky7_Inventory_System_Application.Interfaces;
using Lucky7_Inventory_System_Domain.Entities;
using MediatR;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Commands.StatusCommands.Handlers;

public class UpdateStatusCommandHandler : IRequestHandler<UpdateStatusCommand, GetResponse>
{
    private readonly IGenericRepository<Status> _repository;

    public UpdateStatusCommandHandler(IGenericRepository<Status> repository)
    {
        _repository = repository;
    }

    public async Task<GetResponse> Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var status = await _repository.GetById(request.Status.StatusId);
            if (status == null)
            {
                return new GetResponse(true, null, "Status not found", StatusResponse.notfound);
            }

            status.StatusName = request.Status.StatusName;

            var result = await _repository.Update(status);
            return new GetResponse(true, result, "Status was Successfully Updated", StatusResponse.success);
        }
        catch (Exception ex)
        {
            return new GetResponse(true, null, ex.Message, StatusResponse.unhandled);
        }
    }
}