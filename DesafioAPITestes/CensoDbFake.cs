using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioMundipagg.Model;

namespace DesafioAPITestes
{
    public class CensoDbFake : DesafioMundipagg.Db.ICensoDb
    {
        private readonly List<Pessoa> _pessoas;

        public CensoDbFake()
        {
            Pessoa raiz = new Pessoa() { Nome = "Daniel",Sobrenome="Castro",Escolaridade=Pessoa.Escolaridades.PosGraducao,Genero=Pessoa.Generos.Masculino,Etnia=Pessoa.Etnias.Branco,NomeMae="Marina",NomePai="Eduardo",Filhos=1,Regiao = "Rio de Janeiro"};
            _pessoas.Add(raiz);

            Pessoa paiRaiz = new Pessoa() { Nome = "Eduardo", Sobrenome = "Castro", Escolaridade = Pessoa.Escolaridades.PosGraducao, Genero = Pessoa.Generos.Masculino, Etnia = Pessoa.Etnias.Branco, NomeMae = "Lea", NomePai = "Mario", Filhos = 1, Regiao = "Rio de Janeiro" };
            _pessoas.Add(paiRaiz);

            Pessoa maeRaiz = new Pessoa() { Nome = "Marina", Sobrenome = "Castro", Escolaridade = Pessoa.Escolaridades.PosGraducao, Genero = Pessoa.Generos.Feminino, Etnia = Pessoa.Etnias.Branco, NomeMae = "Ruth", NomePai = "Paulo", Filhos = 1, Regiao = "Rio de Janeiro" };
            _pessoas.Add(maeRaiz);

            Pessoa avoPaiRaiz = new Pessoa() { Nome = "Mario", Sobrenome = "Castro", Escolaridade = Pessoa.Escolaridades.PosGraducao, Genero = Pessoa.Generos.Masculino, Etnia = Pessoa.Etnias.Branco, NomeMae = "MaeMario", NomePai = "PaiMario", Filhos = 1, Regiao = "Rio de Janeiro" };
            _pessoas.Add(avoPaiRaiz);

            Pessoa avoaPaiRaiz = new Pessoa() { Nome = "Lea", Sobrenome = "Castro", Escolaridade = Pessoa.Escolaridades.PosGraducao, Genero = Pessoa.Generos.Feminino, Etnia = Pessoa.Etnias.Branco, NomeMae = "MaeLea", NomePai = "PaiLea", Filhos = 1, Regiao = "Rio de Janeiro" };
            _pessoas.Add(avoaPaiRaiz);

            Pessoa avoMaeRaiz = new Pessoa() { Nome = "Paulo", Sobrenome = "Castro", Escolaridade = Pessoa.Escolaridades.PosGraducao, Genero = Pessoa.Generos.Masculino, Etnia = Pessoa.Etnias.Branco, NomeMae = "MaePaulo", NomePai = "PaiPaulo", Filhos = 1, Regiao = "Rio de Janeiro" };
            _pessoas.Add(avoMaeRaiz);

            Pessoa avoaMaeRaiz = new Pessoa() { Nome = "Ruth", Sobrenome = "Castro", Escolaridade = Pessoa.Escolaridades.PosGraducao, Genero = Pessoa.Generos.Feminino, Etnia = Pessoa.Etnias.Branco, NomeMae = "MaeRuth", NomePai = "PaiRuth", Filhos = 1, Regiao = "Rio de Janeiro" };
            _pessoas.Add(avoaMaeRaiz);

            Pessoa repetido = new Pessoa() { Nome = "Daniel", Sobrenome = "Outro", Escolaridade = Pessoa.Escolaridades.PosGraducao, Genero = Pessoa.Generos.Masculino, Etnia = Pessoa.Etnias.Branco, NomeMae = "X", NomePai = "Y", Filhos = 1, Regiao = "Rio de Janeiro" };
            _pessoas.Add(repetido);
            /*
            raiz.Pai = paiRaiz;
            raiz.Mae = maeRaiz;

            paiRaiz.Pai = avoPaiRaiz;
            paiRaiz.Mae = avoaPaiRaiz;

            maeRaiz.Pai = avoMaeRaiz;
            maeRaiz.Mae = avoaMaeRaiz;
            */


        }

        public Task<Pessoa> Create(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }

        public async Task<Pessoa> Find(string nome)
        {
            return _pessoas.Where(p => p.Nome == nome).FirstOrDefault();
        }

        public async Task<Pessoa> Find(string nome, Pessoa.Generos genero)
        {
            return _pessoas.Where(p => p.Nome == nome && p.Genero == genero).FirstOrDefault();
        }

        public Task<IEnumerable<Pessoa>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Pessoa> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> Percentual(string regiao)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pessoa>> Pesquisa(PessoaFiltro pessoaFiltro)
        {
            throw new NotImplementedException();
        }
    }
}
