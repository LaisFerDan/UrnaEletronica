using FluentAssertions;

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
        public void Urna_ConstrutorIncorreto_RetornaResultadoNaoEquivalente()
        {
            //Arrange
            var urna = new Urna();

            //Act
            var retorno = new Urna()
            {
                VencedorEleicao = "ABC",
                VotosVencedor = 1,
                Candidatos = new List<Candidato>(),
                EleicaoAtiva = true
            };

            //Act + Assert
            retorno.Should().NotBeEquivalentTo(urna);
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
        public void IniciarEncerrarEleicao_IniciadoIncorretamente_RetornaFalso()
        {
            //Arrange
            var urna = new Urna();
            urna.EleicaoAtiva = true;

            //Act
            urna.IniciarEncerrarEleicao();

            //Assert
            urna.EleicaoAtiva.Should().Be(false);
        }

        [Fact]
        public void IniciarEncerrarEleicao_EncerradoCorretamente_RetornaFalso()
        {
            //Arrange
            var urna = new Urna();
            urna.EleicaoAtiva = true;

            //Act
            urna.IniciarEncerrarEleicao();

            //Assert
            urna.EleicaoAtiva.Should().Be(false);
        }

        [Fact]
        public void IniciarEncerrarEleicao_EncerradoIncorretamente_RetornaVerdadeiro()
        {
            //Arrange
            var urna = new Urna();
            urna.EleicaoAtiva = false;

            //Act
            urna.IniciarEncerrarEleicao();

            //Assert
            urna.EleicaoAtiva.Should().Be(true);
        }

        [Theory]
        [InlineData("Fulana")]
        [InlineData("Jurema")]
        [InlineData("Ciclano")]
        public void CadastrarCandidato_UltimoDaListaCadastrado_RetornaVerdadeiro(string nome)
        {
            //Arrange
            var urna = new Urna();

            //Act
            var retorno = urna.CadastrarCandidato(nome);

            //Assert
            retorno.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CadastrarCandidato_NaoFoiUltimoDaListaCadastrado_RetornaFalso(string nome)
        {
            //Arrange
            var urna = new Urna();

            //Act
            var retorno = urna.CadastrarCandidato(nome);

            //Assert
            retorno.Should().BeFalse();
        }

        [Theory]
        [InlineData("")]
        [InlineData("Fulana")]
        public void Votar_CandidatoNaoCadastrado_RetornaFalso(string nome)
        {
            //Arrange
            var urna = new Urna();

            //Act
            urna.CadastrarCandidato("ABC");
            var retorno = urna.Votar(nome);

            //Assert
            retorno.Should().BeFalse();
        }

        [Theory]
        [InlineData("Fulana")]
        [InlineData("CICLANO")]
        [InlineData("jurema")]
        public void Votar_CandidatoCadastrado_RetornaVerdadeiro(string nome)
        {
            //Arrange
            var urna = new Urna();

            //Act
            urna.CadastrarCandidato(nome);
            var retorno = urna.Votar(nome);

            //Assert
            retorno.Should().BeTrue();
        }

        [Theory]
        [InlineData("5789")]
        [InlineData("Fulana")]
        public void MostrarResultadoEleicao_ValidarResultadoCorreto_RetornaQuePossui(string retorno)
        {
            //Arrange
            var urna = new Urna()
            {
                Candidatos = new List<Candidato>() 
                { 
                    new() { Nome = "Fulana", Votos = 5789 },
                    new() { Nome = "Jurema", Votos = 10 }
                }
            };

            //Act
            var resultado = urna.MostrarResultadoEleicao();

            //Assert
            Assert.Contains(retorno, resultado);
        }

        [Theory]
        [InlineData("Jumara")]
        [InlineData("10")]
        public void MostrarResultadoEleicao_ValidarResultadoIncorreto_RetornaQueNaoPossui(string retorno)
        {
            //Arrange
            var urna = new Urna()
            {
                Candidatos = new List<Candidato>()
                {
                    new() { Nome = "Fulana", Votos = 5789 },
                    new() { Nome = "Jurema", Votos = 10 }
                }
            };

            //Act
            var resultado = urna.MostrarResultadoEleicao();

            //Assert
            Assert.DoesNotContain(retorno, resultado);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void MostrarResultadoEleicao_ValidarResultadoVazioOuNulo_RetornaExcecao(string retorno)
        {
            //Arrange
            var urna = new Urna()
            {
                Candidatos = new List<Candidato>()
                {
                    new() { Nome = "Fulana", Votos = 5789 },
                    new() { Nome = "Jurema", Votos = 10 },
                    new() { Nome = retorno, Votos = 10000000 }
                }
            };

            //Act
            Action act = () => urna.MostrarResultadoEleicao();

            //Assert
            act.Should().Throw<Exception>().WithMessage("O vencedor não pode ser nulo ou vazio.");
        }
    }
}
