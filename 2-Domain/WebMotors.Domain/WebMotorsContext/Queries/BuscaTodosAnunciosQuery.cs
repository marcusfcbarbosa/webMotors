using FluentValidator;
using MediatR;
using System;
using WebMotors.Shared.Queries;

namespace WebMotors.Domain.WebMotorsContext.Queries
{
    public class BuscaTodosAnunciosQuery : Notifiable, IQuerie, IRequest<IQueryResult>
    {
        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
