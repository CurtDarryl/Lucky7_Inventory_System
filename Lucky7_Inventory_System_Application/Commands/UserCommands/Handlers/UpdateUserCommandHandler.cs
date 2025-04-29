using Lucky7_Inventory_System_Application.Constants;
using Lucky7_Inventory_System_Application.Interfaces;
using Lucky7_Inventory_System_Application.Services;
using Lucky7_Inventory_System_Domain.Entities;
using MediatR;
using System.Linq.Expressions;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Commands.UserCommands.Handlers;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, GetResponse>
{
    private readonly IGenericRepository<User> _repository;

    public UpdateUserCommandHandler(IGenericRepository<User> repository)
    {
        _repository = repository;
    }

    public async Task<GetResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            Expression<Func<User, bool>> predicate = x => x.UserId == request.User.UserId;
            var user = await _repository.GetSingleWhere(predicate);
            if (user == null)
            {
                return new GetResponse(false, null, "User not found", StatusResponse.notfound);
            }

            EntityUpdater.UpdateProperty(value => user.Firstname = value, user.Firstname, request.User.Firstname);
            EntityUpdater.UpdateProperty(value => user.Lastname = value, user.Lastname, request.User.Lastname);
            EntityUpdater.UpdateProperty(value => user.Password = value, user.Password, request.User.Password);
            EntityUpdater.UpdateProperty(value => user.RoleId = value, user.RoleId, request.User.RoleId);
            EntityUpdater.UpdateProperty(value => user.StatusId = value, user.StatusId, request.User.StatusId);

            var result = await _repository.Update(user);
            return new GetResponse(true, result, "User was Successfully Updated", StatusResponse.success);
        }
        catch (Exception ex)
        {
            return new GetResponse(false, null, ex.Message, StatusResponse.unhandled);
        }
    }
}