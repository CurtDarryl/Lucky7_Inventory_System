using System.Net;
using Lucky7_Inventory_System_Application.Interfaces;
using Lucky7_Inventory_System_Domain.Entities;
using MediatR;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Commands.UomCommands.Handlers;

public class UpdateUomCommandHandler : IRequestHandler<UpdateUomCommand, GetResponse>
{
    private readonly IGenericRepository<Uom> _repository;

    public UpdateUomCommandHandler(IGenericRepository<Uom> repository)
    {
        _repository = repository;
    }

    public async Task<GetResponse> Handle(UpdateUomCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request.Uom == null)
                return new GetResponse(false, null, "Invalid request: Unit of Measure is required", HttpStatusCode.BadRequest);

            var uom = await _repository.GetById(request.Uom.UomId);

            if (uom == null)
                return new GetResponse(true, null, "Unit of Measure Not Found", HttpStatusCode.NotFound);

            uom.UomName = request.Uom.UomName;

            var updatedUom = await _repository.Update(uom);

            return new GetResponse(true, updatedUom, "Successfully Updated Unit of Measure", HttpStatusCode.OK);
        }
        catch (Exception ex)
        {
            return new GetResponse(false, null, ex.Message, HttpStatusCode.InternalServerError);
        }
    }
}