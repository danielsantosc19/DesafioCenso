using DesafioMundipagg.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace DesafioAPITestes
{
    public class CensoControllerTest
    {
        DesafioMundipagg.Controllers.CensoController _controller;
        DesafioMundipagg.Db.ICensoDb _censoDb;

        public CensoControllerTest()
        {
            _censoDb = new CensoDbFake();
            _controller = new DesafioMundipagg.Controllers.CensoController(_censoDb);
        }

        [Fact]
        public void Pesquisa_Chamado_ReturnsOkResult()
        {
            //Act
            //var result = _controller.Pesquisa(new DesafioMundipagg.Model.PessoaFiltro() { Genero = DesafioMundipagg.Model.Pessoa.Generos.Masculino });

            //Assert
            //Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Pesquisa_Nome_Daniel_Retorna_2()
        {
            //Act
            //var result = _controller.Pesquisa(new DesafioMundipagg.Model.PessoaFiltro() { Nome = "Daniel" }).Result;

            // Assert
            //var retorno = Assert.IsType<List<Pessoa>>(result.Value); //Assert.IsAssignableFrom<IEnumerable<Pessoa>>(result.Value);
            //Assert.Equal(2, retorno.Count);
        }
    }
}
