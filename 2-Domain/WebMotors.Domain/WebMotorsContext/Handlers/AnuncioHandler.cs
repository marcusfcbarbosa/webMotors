using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebMotors.Domain.WebMotorsContext.Adapters;
using WebMotors.Domain.WebMotorsContext.Commands.Input;
using WebMotors.Domain.WebMotorsContext.Commands.Output;
using WebMotors.Domain.WebMotorsContext.Entities;
using WebMotors.Domain.WebMotorsContext.Repositories.Interfaces;
using WebMotors.Shared.Commands;

namespace WebMotors.Domain.WebMotorsContext.Handlers
{
    public class AnuncioHandler
            : IRequestHandler<CriaAnuncioCommand, ICommandResult>,
              IRequestHandler<AtualizaAnuncioCommand, ICommandResult>

        
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
            await _anuncioWebMotorsRepository.SaveChangesAsync();
            return await Task.FromResult(new CommandResult(true, "Anuncio cadastrado com sucesso!", entity));
        }

        public async Task<ICommandResult> Handle(AtualizaAnuncioCommand request, CancellationToken cancellationToken)
        {
            var entity = _anuncioWebMotorsRepository.GetById(request.Id);
            if (entity == default(AnuncioWebMotors)) {
                return await Task.FromResult(new CommandResult(false, "Anuncio não encontrado", entity));
            }
            entity.Atualiza(request.Marca, request.Modelo, request.Versao, request.Ano, request.Quilometragem, request.Observacao);
            await _anuncioWebMotorsRepository.SaveChangesAsync();
            return await Task.FromResult(new CommandResult(true, "Anuncio Atualizado com sucesso!", entity));

        }
    }
}
