using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebMotors.Domain.WebMotorsContext.Adapters;
using WebMotors.Domain.WebMotorsContext.Commands.Input;
using WebMotors.Domain.WebMotorsContext.Commands.Output;
using WebMotors.Domain.WebMotorsContext.Repositories.Interfaces;
using WebMotors.Shared.Commands;

namespace WebMotors.Domain.WebMotorsContext.Handlers
{
    public class AnuncioHandler
            : IRequestHandler<CriaAnuncioCommand, ICommandResult>
    {
        private readonly IAnuncioWebMotorsRepository _anuncioWebMotorsRepository;
        public AnuncioHandler(IAnuncioWebMotorsRepository anuncioWebMotorsRepository)
        {
            _anuncioWebMotorsRepository = anuncioWebMotorsRepository;
        }
        public async Task<ICommandResult> Handle(CriaAnuncioCommand request, CancellationToken cancellationToken)
        {
            var entity = AnuncioAdapater.CommandToEntity(request);
            await _anuncioWebMotorsRepository.CreateAsync(entity);
            return await Task.FromResult(new CommandResult(true, "Anuncio cadastrado com sucesso!", request));
        }
    }
}
