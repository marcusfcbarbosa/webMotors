using System.Threading.Tasks;

namespace WebMotors.Shared.Commands
{
    public interface ICommandHandlerAsync<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}
