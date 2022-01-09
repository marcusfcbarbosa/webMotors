using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebMotors.Domain.WebMotorsContext.Commands.Input;
using WebMotors.Domain.WebMotorsContext.Commands.Output;
using WebMotors.Domain.WebMotorsContext.Queries;
using WebMotors.Shared.Commands;
using WebMotors.Shared.Queries;

namespace WebMotors.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnuncioController : BaseController
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


        [HttpGet]
        [Route("{id:int}")]
        public async Task<IQueryResult> Get([FromServices] IMediator mediator, int id)
        {
            var query = new BuscaAnuncioQuery { id = id };
            query.Validate();
            if (query.Valid)
                return await mediator.Send(query);
            return new QueryResult(false, "Erros", query.Notifications);
        }

        [HttpGet]
        [Route("")]
        public async Task<IQueryResult> GetAll([FromServices] IMediator mediator, [FromQuery] BuscaTodosAnunciosQuery query)
        {
            return await mediator.Send(query);
        }



        [HttpDelete]
        public async Task<ICommandResult> Delete([FromServices] IMediator mediator, DeletaAnuncioCommand command)
        {
            command.Validate();
            if (command.Valid)
                return await mediator.Send(command);
            return new CommandResult(false, "Erros", command.Notifications);
        }
    }
}
