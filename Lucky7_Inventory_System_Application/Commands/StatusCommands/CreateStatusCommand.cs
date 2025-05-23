﻿using MediatR;
using static Lucky7_Inventory_System_Application.Responses.ServiceResponses;

namespace Lucky7_Inventory_System_Application.Commands.StatusCommands;

public class CreateStatusCommand : IRequest<GetResponse>
{
    public string? StatusName { get; set; }
}
