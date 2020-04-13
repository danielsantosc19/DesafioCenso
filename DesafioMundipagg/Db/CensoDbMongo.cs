using DesafioMundipagg.Db;
using DesafioMundipagg.Model;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMundipagg.Db
{
    
    public class CensoDbMongo : ICensoDb
    {
        private readonly IMongoCollection<Pessoa> _pessoas;

        public CensoDbMongo(DataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _pessoas = database.GetCollection<Pessoa>("Pessoas");
        }

        public async Task<IEnumerable<Pessoa>> Get()
        {
            return _pessoas.Find(book => true).ToList();
        }

        public async Task<Pessoa> Get(string id) {
            return _pessoas.Find<Pessoa>(p => p.Id == id).FirstOrDefault();
        }

        public async Task<Pessoa> Create(Pessoa pessoa)
        {
            _pessoas.InsertOne(pessoa);
            return pessoa;
        }
        public async Task<decimal> Percentual(string regiao)
        {
            var totalRegiao = _pessoas.AsQueryable().Where(p => p.Regiao.Contains(regiao));
            //var totalRegiao = _pessoas.AsQueryable();

            if (totalRegiao.Count() == 0)
            {
                return 0;
            }
            
            var percentual = totalRegiao
            .GroupBy(p => p.Nome)
            .Select(n => new { nome = n.Key, numero = n.Count() })
            .Where(x => x.numero > 1)
            .Sum(x => x.numero) * 1m;

            return decimal.Round(((percentual/totalRegiao.Count()) * 100),2) ;
        }

        public async Task<Pessoa> Find(string nome,Pessoa.Generos genero)
        {
            return _pessoas.AsQueryable().Where(p => p.Nome == nome && p.Genero == genero).FirstOrDefault();
        }
        public async Task<Pessoa> Find(string nome)
        {
            return _pessoas.AsQueryable().Where(p => p.Nome == nome).FirstOrDefault();
        }

        public async Task<IEnumerable<Pessoa>> Pesquisa(PessoaFiltro pessoaFiltro)
        {
            IQueryable<Pessoa> pessoas = _pessoas.AsQueryable();

            if (!string.IsNullOrEmpty(pessoaFiltro.Nome))
            {
                pessoas = pessoas.Where(p => p.Nome.Contains(pessoaFiltro.Nome));
            }

            if (pessoaFiltro.Escolaridade != null)
            {
                pessoas = pessoas.Where(p => p.Escolaridade == pessoaFiltro.Escolaridade);
            }

            if (pessoaFiltro.Genero != null)
            {
                pessoas = pessoas.Where(p => p.Genero == pessoaFiltro.Genero);
            }

            if (pessoaFiltro.Etnia != null)
            {
                pessoas = pessoas.Where(p => p.Etnia == pessoaFiltro.Etnia);
            }

            if (pessoaFiltro.Filhos.HasValue)
            {
                pessoas = pessoas.Where(p => p.Filhos == pessoaFiltro.Filhos);
            }

            if (!string.IsNullOrEmpty(pessoaFiltro.Regiao))
            {
                pessoas = pessoas.Where(p => p.Regiao == pessoaFiltro.Regiao);
            }

            return pessoas.ToList();

        }


    }
}
