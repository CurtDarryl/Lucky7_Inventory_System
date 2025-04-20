using Lucky7_Inventory_System_Application.Constants;
using Lucky7_Inventory_System_Application.Interfaces;
using Lucky7_Inventory_System_Domain.Entities;
using MediatR;
using System.Linq.Expressions;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Queries.UserQueries.Handlers;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetResponse>
{
    private readonly IGenericRepository<User> _repository;

    public GetUserByIdQueryHandler(IGenericRepository<User> repository)
    {
        _repository = repository;
    }

    public async Task<GetResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            Expression<Func<User, bool>> predicate = u => u.Id == request.Id;
            var user = await _repository.GetSingleWhere(predicate, u => u.Role, u => u.Status);
            if (user == null)
            {
                return new GetResponse(true, null, "No User was found", StatusResponse.notfound);
            }

            return new GetResponse(true, user, "User was Successfully Retrieved", StatusResponse.success);
        }
        catch (Exception ex)
        {
            return new GetResponse(false, null, ex.Message, StatusResponse.unhandled);
        }
    }
}