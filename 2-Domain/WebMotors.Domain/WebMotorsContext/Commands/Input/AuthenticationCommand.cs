using FluentValidator;
using FluentValidator.Validation;
using MediatR;
using WebMotors.Shared.Commands;

namespace WebMotors.Domain.WebMotorsContext.Commands.Input
{
    public class AuthenticationCommand : Notifiable, ICommand, IRequest<ICommandResult>
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }

        public void Validate()
        {
            AddNotifications(new ValidationContract()
                 .Requires()
                 .IsNotNullOrEmpty(UserName, "UserName", "UserName é obrigatório")
             );
            AddNotifications(new ValidationContract()
                .Requires()
                .IsNotNullOrEmpty(PassWord, "PassWord", "PassWord é obrigatório")
            );
        }
    }
}
