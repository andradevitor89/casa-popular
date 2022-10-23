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
        var random = new Random();
        var familias = new List<Familia>();
        for (int i = 0; i < 10000; i++)
        {
            var familia = FamiliaMock.Criar(dependentes: random.Next(0, 5),
                                            renda: random.Next(0, 2000));
            familias.Add(familia);
        }

        var familiasOrdenadas = _avaliador.Executar(familias);

        familiasOrdenadas.Should().BeInDescendingOrder(familia => familia.Pontuacao);
        familiasOrdenadas.Should().HaveCount(familias.Count);
    }
}
