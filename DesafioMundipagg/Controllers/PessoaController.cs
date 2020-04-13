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
    public class PessoaController : ControllerBase
    {
        private readonly ICensoDb censoDb;

        public PessoaController(ICensoDb censoDb)
        {
            this.censoDb = censoDb;
        }

        // POST api/pessoa
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        /// <summary>
        /// Cadastra uma nova pessoa no censo 
        /// </summary>
        public async Task<ActionResult<Pessoa>> Post([FromForm] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                await censoDb.Create(pessoa);
                return CreatedAtAction(nameof(GetPessoa), new { id = pessoa.Id }, pessoa);
            }

            return BadRequest();
        }

        // GET api/pessoa?id=
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        /// <summary>
        /// Obtem uma pessoa pelo seu id
        /// </summary>
        public async Task<ActionResult<Pessoa>> GetPessoa([FromQuery]string id)
        {
            Pessoa pessoa = await censoDb.Get(id);
            
            if (pessoa == null)
            {
                return NotFound();
            }

            return pessoa;
        }
    }
}