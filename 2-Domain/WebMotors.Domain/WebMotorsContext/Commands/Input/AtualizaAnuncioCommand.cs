using FluentValidator;
using FluentValidator.Validation;
using MediatR;
using WebMotors.Shared.Commands;

namespace WebMotors.Domain.WebMotorsContext.Commands.Input
{
    public class AtualizaAnuncioCommand : Notifiable, ICommand, IRequest<ICommandResult>
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Versao { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public string Observacao { get; set; }
        public void Validate()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .IsLowerThan(0, Id, "Id", "Id precisa ser superior a ZERO")
            );

            AddNotifications(new ValidationContract()
                .Requires()
                    .IsNotNullOrEmpty(Marca, "Marca", "Marca é obrigatorio")
                );
            AddNotifications(new ValidationContract()
                .Requires()
                .IsNotNullOrEmpty(Modelo, "Modelo", "Modelo é obrigatorio")
                );
            AddNotifications(new ValidationContract()
                .Requires()
                .IsNotNullOrEmpty(Versao, "Versao", "Versao é obrigatorio")
                );

            AddNotifications(new ValidationContract()
                .Requires()
                .IsLowerThan(0, Ano, "Ano", "Ano precisa ser superior a ZERO")
            );
            AddNotifications(new ValidationContract()
                .Requires()
                .IsLowerThan(0, Quilometragem, "Quilometragem", "Quilometragem precisa ser superior a ZERO")
            );
        }
    }
}
