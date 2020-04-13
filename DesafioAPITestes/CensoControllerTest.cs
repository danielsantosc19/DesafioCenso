using System;
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
            //var okResult = _controller.Pesquisa(new DesafioMundipagg.Model.PessoaFiltro() { Genero = DesafioMundipagg.Model.Pessoa.Generos.Masculino });
        }
    }
}
