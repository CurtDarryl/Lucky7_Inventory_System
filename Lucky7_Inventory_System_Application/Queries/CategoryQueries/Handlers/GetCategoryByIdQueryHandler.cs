using System.Net;
using Lucky7_Inventory_System_Application.Interfaces;
using Lucky7_Inventory_System_Domain.Entities;
using MediatR;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Queries.CategoryQueries.Handlers;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetResponse>
{
    private readonly IGenericRepository<Category> _repository;

    public GetCategoryByIdQueryHandler(IGenericRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task<GetResponse> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var category = await _repository.GetById(request.Id);

            if (category == null)
            {
                return new GetResponse(true, null, "Category not found", HttpStatusCode.NotFound);
            }

            return new GetResponse(true, category, "Successfully Rerieved Category", HttpStatusCode.OK);
        }
        catch (Exception ex)
        {
            return new GetResponse(true, null, ex.Message, HttpStatusCode.InternalServerError);
        }
    }
}