using FluentValidator;
using FluentValidator.Validation;
using MediatR;
using WebMotors.Shared.Queries;

namespace WebMotors.Domain.WebMotorsContext.Queries
{
    public class BuscaAnuncioQuery : Notifiable, IQuerie, IRequest<IQueryResult>
    {
        public int id { get; set; }
        public void Validate()
        {
            AddNotifications(new ValidationContract()
               .Requires()
                .IsLowerThan(0, id, "id", "id deve ser maior que zero (0)")
               );
        }
    }
}
