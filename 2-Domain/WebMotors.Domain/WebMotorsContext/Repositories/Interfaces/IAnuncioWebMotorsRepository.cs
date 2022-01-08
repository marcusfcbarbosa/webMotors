using System.Collections.Generic;
using System.Threading.Tasks;
using WebMotors.Domain.WebMotorsContext.Entities;

namespace WebMotors.Domain.WebMotorsContext.Repositories.Interfaces
{
    public interface IAnuncioWebMotorsRepository : IBaseRepository<AnuncioWebMotors>
    {
        Task<IEnumerable<AnuncioWebMotors>> GetAll();

    }
}
