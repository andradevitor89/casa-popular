using Aplicacao;
using Dominio;
using FluentAssertions;
using Moq;
using Xunit;

namespace Testes;

public class OrdenadorTeste
{
    private readonly IOrdenador _ordenador;
    private readonly Mock<IAvaliador> _avaliador;

    public OrdenadorTeste()
    {
        _avaliador = new Mock<IAvaliador>();
        _ordenador = new Ordenador(_avaliador.Object);
    }

    [Fact]
    public void Executar_DeveRetornarListaDeFamiliasOrdenadasPelaPontuacao()
    {
        var familias = new[]
        {
            FamiliaMock.Criar(),
            FamiliaMock.Criar(),
            FamiliaMock.Criar(),
            FamiliaMock.Criar(),
            FamiliaMock.Criar(),
            FamiliaMock.Criar(),
            FamiliaMock.Criar()
        };

        var familiasOrdenadas = _ordenador.Executar(familias);
        familiasOrdenadas.Should().BeInDescendingOrder(familia => familia.Pontuacao);
        familiasOrdenadas.Should().HaveCount(familias.Length);
        _avaliador.Verify(a => a.Executar(It.IsAny<Familia>()), Times.Exactly(familias.Length));
    }
}
