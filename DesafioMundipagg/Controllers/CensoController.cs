using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioMundipagg.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DesafioMundipagg.Db;

namespace DesafioMundipagg.Controllers
{

    /// <summary>
    /// Api para cadastramento e pesquisa de censo demografico
    /// </summary>
    

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CensoController : ControllerBase
    {
        private readonly ICensoDb censoDb;

        public CensoController(ICensoDb censoDb)
        {
            this.censoDb = censoDb;
        }
        
        
        //api/censo/percentual?regiao=Rio de Janeiro
        [HttpGet("percentual", Name = "Percentual", Order = 0)]
        /// <summary>
        /// Retorna o percentual de pessoas com o mesmo nome de uma região 
        /// </summary>
        public async Task<ActionResult<decimal>> Percentual([FromQuery] string regiao = "")
        {
            return await censoDb.Percentual(regiao);
        }
        
        [Produces("application/json")]
        [HttpGet("arvore", Name = "Arvore", Order = 0)]
        /// <summary>
        /// Monta uma arvore genealógica de uma pessoa até o nivel informado.
        /// TODO: Buscar os irmãos do atual nó, baseado nos pais em comum...
        /// TODO: Montar uma lista com os ids já inseridos na arvore para não repeti-los em outro nivel da arvore...
        /// </summary>
        public async Task<ActionResult<Pessoa>> Arvore([FromQuery] string nome = "",int nivel = 5)
        {   
            Pessoa raiz = await censoDb.Find(nome);
            if (raiz != null)
            {
                MontaArvore(raiz,1, nivel);                
            }

            return raiz;
        }

        // GET api/censo/pesquisa?nome=daniel&genero=masculino        
        [HttpGet("pesquisa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        ///<summary>
        ///Realiza pesquisa com filtros de pessoas
        ///</summary>
        public async Task<ActionResult<IEnumerable<Pessoa>>> Pesquisa([FromQuery] PessoaFiltro pessoaFiltro)
        {
            if (pessoaFiltro == null)
            {
                return BadRequest("Pesquisa inválida");
            }

            IEnumerable<Pessoa> pessoas = await censoDb.Pesquisa(pessoaFiltro);

            return Ok(censoDb.Pesquisa(pessoaFiltro));
        }

        private async void MontaArvore(Pessoa noPessoa, int nivelAtual, int nivelMaximo)
        {
            if (nivelAtual > nivelMaximo || noPessoa == null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(noPessoa.NomeMae))
            {
                noPessoa.Mae = await censoDb.Find(noPessoa.NomeMae, Pessoa.Generos.Feminino);
                MontaArvore(noPessoa.Mae, nivelAtual + 1, nivelMaximo);
            }
            if (!string.IsNullOrEmpty(noPessoa.NomePai))
            {
                noPessoa.Pai = await censoDb.Find(noPessoa.NomePai, Pessoa.Generos.Masculino);
                MontaArvore(noPessoa.Pai, nivelAtual + 1, nivelMaximo);
            }
        }

    }
}