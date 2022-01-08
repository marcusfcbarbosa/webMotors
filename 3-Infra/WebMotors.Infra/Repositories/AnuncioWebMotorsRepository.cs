using WebMotors.Domain.WebMotorsContext.Entities;
using WebMotors.Domain.WebMotorsContext.Repositories.Interfaces;
using WebMotors.Infra.SqlContext;

namespace WebMotors.Infra.Repositories
{
    public class AnuncioWebMotorsRepository : BaseRepository<AnuncioWebMotors>, IAnuncioWebMotorsRepository
    {
        private readonly WebMotorsContext _context;
        public AnuncioWebMotorsRepository(WebMotorsContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
