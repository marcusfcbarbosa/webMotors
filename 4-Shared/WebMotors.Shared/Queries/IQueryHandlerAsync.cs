using System.Threading.Tasks;

namespace WebMotors.Shared.Queries
{
    public interface IQueryHandlerAsync<T> where T : IQuerie
    {
        Task<IQueryResult> Handle(T querie);
    }
}
