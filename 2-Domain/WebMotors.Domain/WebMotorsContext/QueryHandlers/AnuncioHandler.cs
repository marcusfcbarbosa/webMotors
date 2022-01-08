using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebMotors.Domain.WebMotorsContext.Adapters;
using WebMotors.Domain.WebMotorsContext.Commands.Output;
using WebMotors.Domain.WebMotorsContext.Entities;
using WebMotors.Domain.WebMotorsContext.Queries;
using WebMotors.Domain.WebMotorsContext.Repositories.Interfaces;
using WebMotors.Shared.Queries;

namespace WebMotors.Domain.WebMotorsContext.QueryHandlers
{
    public class AnuncioHandler : 
        IRequestHandler<BuscaAnuncioQuery, IQueryResult>,
        IRequestHandler<BuscaTodosAnunciosQuery, IQueryResult>
        
    {
        private readonly IAnuncioWebMotorsRepository _anuncioWebMotorsRepository;
        public AnuncioHandler(IAnuncioWebMotorsRepository anuncioWebMotorsRepository)
        {
            _anuncioWebMotorsRepository = anuncioWebMotorsRepository;
        }
        public async Task<IQueryResult> Handle(BuscaAnuncioQuery request, CancellationToken cancellationToken)
        {
            var entity = _anuncioWebMotorsRepository.GetById(request.id);
            if (entity == default(AnuncioWebMotors))
            {
                return await Task.FromResult(new QueryResult(false, "Anuncio não encontrado", entity));
            }
            return await Task.FromResult(new QueryResult(true, "", entity));
        }

        public async Task<IQueryResult> Handle(BuscaTodosAnunciosQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new QueryResult(true, "", AnuncioAdapater.EntityToModel(await _anuncioWebMotorsRepository.GetAll())));
        }
    }
}