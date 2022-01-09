using FluentValidator;
using FluentValidator.Validation;
using MediatR;
using WebMotors.Shared.Commands;

namespace WebMotors.Domain.WebMotorsContext.Commands.Input
{
    public class DeletaAnuncioCommand : Notifiable, ICommand, IRequest<ICommandResult>
    {
        public int Id { get; set; }
        public void Validate()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .IsLowerThan(0, Id, "Id", "Id precisa ser superior a ZERO")
            );
        }
    }
}
