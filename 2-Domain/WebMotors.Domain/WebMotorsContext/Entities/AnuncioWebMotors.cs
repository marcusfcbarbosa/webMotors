using WebMotors.Shared.Entities;

namespace WebMotors.Domain.WebMotorsContext.Entities
{
    public class AnuncioWebMotors : Entity
    {
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public string Versao { get; private set; }
        public int Ano { get; private set; }
        public string Quilometragem { get; private set; }
        public string Observao { get; private set; }
        private AnuncioWebMotors() { }
        public AnuncioWebMotors(string marca, string modelo, string versao, int ano, string quilometragem, string observao) : this()
        {
            Marca = marca;
            Modelo = modelo;
            Versao = versao;
            Ano = ano;
            Quilometragem = quilometragem;
            Observao = observao;
        }



    }
}
