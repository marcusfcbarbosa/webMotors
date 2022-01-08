using System.Collections.Generic;
using System.Linq;
using WebMotors.Domain.WebMotorsContext.Commands.Input;
using WebMotors.Domain.WebMotorsContext.Entities;
using WebMotors.Domain.WebMotorsContext.Models;

namespace WebMotors.Domain.WebMotorsContext.Adapters
{
    /// <summary>
    /// Podia ter usado AutoMapper, mas algumas bibliotes que fazem uso de reflexion, deixam aplicação mais lenta, quando trafego de dados aumenta
    /// </summary>
    public static class AnuncioAdapater
    {
        public static AnuncioWebMotors CommandToEntity(CriaAnuncioCommand command)
        {
            return new AnuncioWebMotors(command.Marca, command.Modelo, command.Versao, command.Ano, command.Quilometragem, command.Observacao);
        }

        public static IEnumerable<AnuncioWebMotorsModel> EntityToModel(IEnumerable<AnuncioWebMotors> entities)
        {
            List<AnuncioWebMotorsModel> list = new List<AnuncioWebMotorsModel>();
            for (int i = 0; i < entities.Count(); i++)
            {
                list.Add(new AnuncioWebMotorsModel
                {
                    Id = entities.ElementAt(i).Id,
                    Marca = entities.ElementAt(i).Marca,
                    Modelo = entities.ElementAt(i).Modelo,
                    Versao = entities.ElementAt(i).Versao,
                    Ano = entities.ElementAt(i).Ano,
                    Quilometragem = entities.ElementAt(i).Quilometragem,
                    Observacao = entities.ElementAt(i).Observacao,
                });
            }
            return list;
        }
    }
}

