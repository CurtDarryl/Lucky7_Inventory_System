using Lucky7_Inventory_System_Application.Constants;
using Lucky7_Inventory_System_Application.Interfaces;
using Lucky7_Inventory_System_Domain.Entities;
using MediatR;
using System.Linq.Expressions;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Queries.UserQueries.Handlers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, GetResponse>
{
    private readonly IGenericRepository<User> _repository;

    public GetAllUsersQueryHandler(IGenericRepository<User> repository)
    {
        _repository = repository;
    }

    public async Task<GetResponse> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var users = await _repository.GetAll();
            if (!users.Any())
            {
                return new GetResponse(true, null, "No Users were Found", StatusResponse.notfound);
            }
            return new GetResponse(true, users, "Users were Successfully Retrieved", StatusResponse.success);
        }
        catch (Exception ex)
        {
            return new GetResponse(false, null, ex.Message, StatusResponse.unhandled);
        }
    }
}