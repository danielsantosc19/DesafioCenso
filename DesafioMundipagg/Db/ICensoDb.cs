using DesafioMundipagg.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMundipagg.Db
{
    public interface ICensoDb
    {
        Task<IEnumerable<Pessoa>> Get();
        Task<Pessoa> Get(string id);
        Task<Pessoa> Create(Pessoa pessoa);
        Task<decimal> Percentual(string regiao);

        Task<Pessoa> Find(string nome);
        Task<Pessoa> Find(string nome,Pessoa.Generos genero);
        Task<IEnumerable<Pessoa>> Pesquisa(PessoaFiltro pessoaFiltro);
    }
}
