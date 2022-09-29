using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrnaEletronica
{
    public class Candidato
    {
        public string Nome { get; set; }
        public int Votos { get; set; }
        public Candidato(string nome)
        {
            Nome = nome;
        }

        public Candidato()
        {
        }

        public void AdicionarVoto() => Votos++;
        public int RetornarVotos() => Votos;
        public bool ValidarQuantidadeDeVotos(int votos)
        {
            if (Votos == votos)
                return true;
            return false;
        }

        public string ValidarNomeDoCandidato(string nome)
        {
            if (!Nome.Equals(nome, StringComparison.InvariantCultureIgnoreCase) || string.IsNullOrEmpty(nome))
                throw new Exception("O nome do candidato não está correto.");
            return nome;
        }
    }
}
