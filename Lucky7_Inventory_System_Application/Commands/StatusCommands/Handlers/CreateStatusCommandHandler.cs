using Lucky7_Inventory_System_Application.Constants;
using Lucky7_Inventory_System_Application.Interfaces;
using Lucky7_Inventory_System_Domain.Entities;
using MediatR;
using System.Linq.Expressions;
using System.Net;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Commands.StatusCommands.Handlers;

public class CreateStatusCommandHandler : IRequestHandler<CreateStatusCommand, GetResponse>
{
    private readonly IGenericRepository<Status> _repository;

    public CreateStatusCommandHandler(IGenericRepository<Status> repository)
    {
        _repository = repository;
    }

    public async Task<GetResponse> Handle(CreateStatusCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var status = new Status
            {
                StatusName = request.StatusName,
            };

            Expression<Func<Status, bool>> predicate = u => u.StatusName == request.StatusName;
            var occured = await _repository.GetSingleWhere(predicate);
            if (occured != null) 
            {
                return new GetResponse(true, null, "This Status Already Exist", HttpStatusCode.NotAcceptable);
            }

            var result = await _repository.Add(status);

            return new GetResponse(true, result, "Status was Successfully Added", HttpStatusCode.OK);
        }
        catch (Exception ex) 
        {
            return new GetResponse(true, null, ex.Message, HttpStatusCode.InternalServerError);
        }
    }
}
