using Lucky7_Inventory_System_Application.Interfaces;
using Lucky7_Inventory_System_Domain.Entities;
using MediatR;
using System.Net;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Commands.CategoryCommands.Handlers;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, GetResponse>
{
    private readonly IGenericRepository<Category> _repository;

    public DeleteCategoryCommandHandler(IGenericRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task<GetResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var category = await _repository.GetById(request.CategoryId);
            if (category == null)
                return new GetResponse(true, null, "Category Not Found", HttpStatusCode.NotFound);

            await _repository.Delete(category);

            return new GetResponse(true, category, "Category Deleted Successfully", HttpStatusCode.OK);
        }
        catch (Exception ex)
        {
            return new GetResponse(false, null, ex.Message, HttpStatusCode.InternalServerError);
        }
    }
}