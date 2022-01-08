using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebMotors.Domain.WebMotorsContext.Commands.Input;

namespace WebMotors.Test.Commands
{
    [TestClass]
    public class CriaAnuncioCommandTest
    {
        private readonly CriaAnuncioCommand _invalidCommand = new CriaAnuncioCommand {  Marca = string.Empty, Modelo = string.Empty, Versao = string.Empty, Ano = 0, Quilometragem = 0, Observacao = String.Empty };
        private readonly CriaAnuncioCommand _validCommand = new CriaAnuncioCommand {  Marca = "volkswagen", Modelo = "Amarok", Versao = "Blas", Ano = 2022, Quilometragem = 10, Observacao = String.Empty };

        public CriaAnuncioCommandTest()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }
        //RED GREEN REFACTOR
        [TestMethod]
        public void DadoCommandoInvalido()
        {
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod]
        public void DadoCommandovalido()
        {
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}
