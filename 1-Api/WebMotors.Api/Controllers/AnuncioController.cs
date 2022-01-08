﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebMotors.Domain.WebMotorsContext.Commands.Input;
using WebMotors.Domain.WebMotorsContext.Commands.Output;
using WebMotors.Shared.Commands;

namespace WebMotors.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnuncioController : ControllerBase
    {

        [HttpPost]
        [Route("")]
        public async Task<ICommandResult> Create([FromServices] IMediator mediator,
                                                 [FromBody] CriaAnuncioCommand command)
        {
            command.Validate();
            if (command.Valid)
                return await mediator.Send(command);
            return new CommandResult(false, "Erros", command.Notifications);
        }

    }
}
