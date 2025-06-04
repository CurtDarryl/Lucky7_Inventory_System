using System.Net;
using Lucky7_Inventory_System_Application.Interfaces;
using Lucky7_Inventory_System_Domain.Entities;
using MediatR;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Queries.CategoryQueries.Handlers;

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, GetResponse>
{
    private readonly IGenericRepository<Category> _repository;

    public GetAllCategoriesQueryHandler(IGenericRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task<GetResponse> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var categories = await _repository.GetAll();

            if (categories == null || !categories.Any())
            {
                return new GetResponse(true, null, "No Categories were Found", HttpStatusCode.NotFound);
            }
            return new GetResponse(true, categories, "Categories were Successfully Retrieved", HttpStatusCode.OK);
        }
        catch (Exception ex)
        {
            return new GetResponse(false, null, ex.Message, HttpStatusCode.InternalServerError);
        }
    }
}