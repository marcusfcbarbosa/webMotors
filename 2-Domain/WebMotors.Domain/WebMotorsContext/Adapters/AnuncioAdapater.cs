using WebMotors.Domain.WebMotorsContext.Commands.Input;
using WebMotors.Domain.WebMotorsContext.Entities;

namespace WebMotors.Domain.WebMotorsContext.Adapters
{
    public static  class AnuncioAdapater
    {
        public static AnuncioWebMotors CommandToEntity(CriaAnuncioCommand command) {
            return new AnuncioWebMotors(command.Marca, command.Modelo, command.Versao, command.Ano, command.Quilometragem, command.Observacao);
        }
    }
}
