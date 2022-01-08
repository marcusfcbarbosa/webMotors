using MediatR;
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
        public async Task<ICommandResult> Post([FromServices] IMediator mediator,
                                                 [FromBody] CriaAnuncioCommand command)
        {
            command.Validate();
            if (command.Valid)
                return await mediator.Send(command);
            return new CommandResult(false, "Erros", command.Notifications);
        }


        [HttpPut]
        [Route("")]
        public async Task<ICommandResult> Put([FromServices] IMediator mediator,
                                                 [FromBody] AtualizaAnuncioCommand command)
        {
            command.Validate();
            if (command.Valid)
                return await mediator.Send(command);
            return new CommandResult(false, "Erros", command.Notifications);
        }
    }
}
