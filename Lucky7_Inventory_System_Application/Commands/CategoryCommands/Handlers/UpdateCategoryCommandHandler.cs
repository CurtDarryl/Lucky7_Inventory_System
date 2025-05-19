using Lucky7_Inventory_System_Application.Interfaces;
using Lucky7_Inventory_System_Domain.Entities;
using MediatR;
using System.Net;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Commands.CategoryCommands.Handlers;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, GetResponse>
{
    private readonly IGenericRepository<Category> _repository;

    public UpdateCategoryCommandHandler(IGenericRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task<GetResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var category = await _repository.GetById(request.Category.CategoryId);

            if (category == null)
                return new GetResponse(true, null, "Category Not Found", HttpStatusCode.NotFound);

            category.CategoryName = request.Category.CategoryName;

            var updatedCategory = await _repository.Update(category);

            return new GetResponse(true, updatedCategory, "Successfully Updated Category", HttpStatusCode.OK);
        }
        catch (Exception ex)
        {
            return new GetResponse(false, null, ex.Message, HttpStatusCode.InternalServerError);
        }
    }
}