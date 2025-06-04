using System.Net;
using Lucky7_Inventory_System_Application.Interfaces;
using Lucky7_Inventory_System_Domain.Entities;
using MediatR;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Commands.UomCommands.Handlers;

public class DeleteUomCommandHandler : IRequestHandler<DeleteUomCommand, GetResponse>
{
    private readonly IGenericRepository<Uom> _repository;

    public DeleteUomCommandHandler(IGenericRepository<Uom> repository)
    {
        _repository = repository;
    }

    public async Task<GetResponse> Handle(DeleteUomCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var uom = await _repository.GetById(request.UomId);

            if (uom == null)
                return new GetResponse(true, null, "Unit of Measure Not Found", HttpStatusCode.NotFound);

            await _repository.Delete(uom);

            return new GetResponse(true, uom, "Unit of Measure Deleted Successfully", HttpStatusCode.OK);
        }
        catch (Exception ex)
        {
            return new GetResponse(false, null, ex.Message, HttpStatusCode.InternalServerError);
        }
    }
}