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

        [Fact]
        public void ValidarNomeDoCandidato_NomeCorreto_RetornaVerdadeiro()
        {
            //Arrange
            var nome = "Fulana";

            //Act
            var retorno = candidatoFake.ValidarNomeDoCandidato(nome);

            //Assert
            Assert.Equal(nome, retorno);
        }
    }
}