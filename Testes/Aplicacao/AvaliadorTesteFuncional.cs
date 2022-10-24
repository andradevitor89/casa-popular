using Aplicacao;
using Dominio;
using FluentAssertions;
using Mocks;
using Xunit;

namespace Testes.Aplicacao;

public class AvaliadorTesteFuncional
{
    private readonly IAvaliador _avaliador;

    public AvaliadorTesteFuncional()
    {
        _avaliador = new Avaliador(new CalculadoraPontuacaoRenda(), new CalculadoraPontuacaoDependentes());
    }

    [Fact]
    public void Executar_DeveRetornarListaDeFamiliasOrdenadasPelaPontuacao()
    {
        var familias = FamiliaMock.CriarMultiplas(quantidade: 10000);

        var familiasOrdenadas = _avaliador.Executar(familias);

        familiasOrdenadas.Should().BeInDescendingOrder(familia => familia.Pontuacao);
        familiasOrdenadas.Should().HaveCount(familias.Count());
    }
}
