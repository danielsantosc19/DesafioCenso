using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMundipagg.Model
{
    [Serializable()]
    public class PessoaFiltro
    {
        public Pessoa.Etnias? Etnia { get; set; }

        public string Nome { get; set; }

        public Pessoa.Escolaridades? Escolaridade { get; set; }

        public Pessoa.Generos? Genero { get; set; }

        public int? Filhos { get; set; }

        public string Regiao { get; set; }
    }
}
