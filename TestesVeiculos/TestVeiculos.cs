using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WebVeiculosCrud.Controllers;
using WebVeiculosCrud.Data;
using WebVeiculosCrud.Models;

namespace TestesVeiculos
{
    [TestClass]
    public class TestVeiculos 
    {
        VeiculosModel veiculo = new VeiculosModel();

        private readonly ApplicationDbContext _dbCont;


        [TestMethod]
        public void CriarTeste()
        {
            //veiculo.Id = 4;
            veiculo.Marca = "Citroen";
            veiculo.Modelo = "C#";
            veiculo.Versao = "1.4";
            veiculo.Ano = 2004;
            veiculo.Quilometragem = 160;
            veiculo.Observacao = "Pequena avaria";


            var resul = _dbCont.VeiculosModel.Add(veiculo);
            Assert.AreEqual(true, resul);

        }
    }
}
