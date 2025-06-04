using Lucky7_Inventory_System_Application.Commands.UomCommands;
using Lucky7_Inventory_System_Application.Constants;
using Lucky7_Inventory_System_Application.Interfaces;
using Lucky7_Inventory_System_Domain.Entities;
using MediatR;
using System.Linq.Expressions;
using System.Net;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Commands.UomCommands.Handlers;

public class CreateUomCommandHandler : IRequestHandler<CreateUomCommand, GetResponse>
{
    private readonly IGenericRepository<Uom> _repository;

    public CreateUomCommandHandler(IGenericRepository<Uom> repository)
    {
        _repository = repository;
    }

    public async Task<GetResponse> Handle(CreateUomCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var uomName = request.UomName;

            if (string.IsNullOrWhiteSpace(uomName))
                return new GetResponse(false, null, "Unit of Measure name is required", HttpStatusCode.BadRequest);

            Expression<Func<Uom, bool>> predicate = u => u.UomName != null && u.UomName.Equals(uomName, StringComparison.CurrentCultureIgnoreCase);
            var uom = await _repository.GetSingleWhere(predicate);

            if (uom != null)
                return new GetResponse(true, null, "Unit of Measure Already Exist", HttpStatusCode.BadRequest);

            var category = new Uom
            {
                UomName = request.UomName,
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