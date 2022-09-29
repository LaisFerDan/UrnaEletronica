using FluentAssertions;

namespace UrnaEletronica.Tests
{
    public class CandidatoTests
    {
        private readonly Candidato candidatoFake = new Candidato() { Nome = "Fulana", Votos = 0};

        [Fact]
        public void ValidarQuantidadeDeVotos_VotosCorretosAposCadastro_RetornaVerdadeiro()
        {
            //Arrange
            var voto = 0;

            //Act
            var retorno = candidatoFake.ValidarQuantidadeDeVotos(voto);

            //Assert
            retorno.Should()
                .BeTrue();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(7897)]
        [InlineData(555)]
        [InlineData(-1)]
        public void ValidarQuantidadeDeVotos_VotosIncorretosAposCadastro_RetornaFalso(int voto)
        {
            //Arrange + Act
            var retorno = candidatoFake.ValidarQuantidadeDeVotos(voto);

            //Assert
            retorno.Should()
                .BeFalse();
        }

        [Fact]
        public void ValidarQuantidadeDeVotos_VotosCorretosAposNovoVoto_RetornaVerdadeiro()
        {
            //Arrange
            var voto = 1;

            //Act
            candidatoFake.AdicionarVoto();
            var retorno = candidatoFake.ValidarQuantidadeDeVotos(voto);

            //Assert
            retorno.Should()
                .BeTrue();
        }

        [Theory]
        [InlineData(2)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(500)]
        public void ValidarQuantidadeDeVotos_VotosIncorretosAposNovoVoto_RetornaFalso(int voto)
        {
            //Arrange + Act
            candidatoFake.AdicionarVoto();
            var retorno = candidatoFake.ValidarQuantidadeDeVotos(voto);

            //Assert
            retorno.Should()
                .BeFalse();
        }

        [Theory]
        [InlineData("Fulana")]
        [InlineData("fulana")]
        [InlineData("FULANA")]
        public void ValidarNomeDoCandidato_NomeCorreto_RetornaValorIgual(string nome)
        {
            //Arrange + Act
            var retorno = candidatoFake.ValidarNomeDoCandidato(nome);

            //Assert
            Assert.Equal(nome, retorno);
        }

        [Theory]
        [InlineData("Ciclana")]
        [InlineData("Fulano")]
        [InlineData("")]
        [InlineData(null)]
        public void ValidarNomeDoCandidato_NomeIncorreto_RetornaExcecao(string nome)
        {
            //Arrange + Act
            Action act = () => candidatoFake.ValidarNomeDoCandidato(nome);

            //Assert
            act.Should().Throw<Exception>().WithMessage("O nome do candidato não está correto.");
        }
    }
}