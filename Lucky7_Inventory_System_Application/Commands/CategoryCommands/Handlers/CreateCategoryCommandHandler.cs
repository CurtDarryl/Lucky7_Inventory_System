using Lucky7_Inventory_System_Application.Constants;
using Lucky7_Inventory_System_Application.Interfaces;
using Lucky7_Inventory_System_Domain.Entities;
using MediatR;
using System.Net;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Commands.CategoryCommands.Handlers;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, GetResponse>
{
    private readonly IGenericRepository<Category> _repository;

    public CreateCategoryCommandHandler(IGenericRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task<GetResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request.CategoryName == null)
                return new GetResponse(true, null, "This Role Already Exist", HttpStatusCode.BadRequest);

            var category = new Category
            {
                CategoryName = request.CategoryName,
            };

            await _repository.Add(category);

            return new GetResponse(true, category, "Successfully Added Category", HttpStatusCode.OK);
        }
        catch (Exception ex)
        {
            return new GetResponse(false, null, ex.Message, HttpStatusCode.InternalServerError);
        }
    }
}