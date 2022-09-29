using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrnaEletronica.Tests
{
    public class UrnaTests
    {
        [Fact]
        public void Urna_ConstrutorCorreto_RetornaResultadoIgual()
        {
            //Arrange
            var urna = new Urna();
            
            //Act
            var retorno = new Urna()
            {
                VencedorEleicao = "",
                VotosVencedor = 0,
                Candidatos = new List<Candidato>(),
                EleicaoAtiva = false
            };

            //Assert
            retorno.Should().BeEquivalentTo(urna);
        }

        [Fact]
        public void IniciarEncerrarEleicao_IniciadoCorretamente_RetornaVerdadeiro()
        {
            //Arrange
            var urna = new Urna();
            urna.EleicaoAtiva = false;

            //Act
            urna.IniciarEncerrarEleicao();

            //Assert
            urna.EleicaoAtiva.Should().Be(true);
        }

        [Fact]
        public void IniciarEncerrarEleicao_EncerradoCorretamente_RetornaVerdadeiro()
        {
            //Arrange
            var urna = new Urna();
            urna.EleicaoAtiva = true;

            //Act
            urna.IniciarEncerrarEleicao();

            //Assert
            urna.EleicaoAtiva.Should().Be(false);
        }
         // - Validar se, ao cadastrar um candidato, o última candidato na lista é o mesmo que foi cadastrado
         public void CadastrarCandidato_UltimoDaListaCadastrado_RetornarCandidato()
        {

        }
         // - Validar o método de votação quando é informado um candidato não cadastrado
         // - Validar o método de votação quando é informado um candidato cadastrado
         // - Validar o resultado da eleição
         
    }
}
