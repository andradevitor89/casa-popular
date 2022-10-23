using Aplicacao;
using Dominio;
using FluentAssertions;
using Mocks;
using Moq;
using Xunit;

namespace Testes.Aplicacao;

public class AvaliadorTeste
{
    private readonly IAvaliador _avaliador;
    private readonly Mock<ICalculadoraPontuacaoRenda> _calculadoraPontuacaoRenda;
    private readonly Mock<ICalculadoraPontuacaoDependentes> _calculadoraPontuacaoDependentes;

    public AvaliadorTeste()
    {
        _calculadoraPontuacaoRenda = new Mock<ICalculadoraPontuacaoRenda>();
        _calculadoraPontuacaoDependentes = new Mock<ICalculadoraPontuacaoDependentes>();
        _avaliador = new Avaliador(_calculadoraPontuacaoRenda.Object, _calculadoraPontuacaoDependentes.Object);
    }

    [Fact]
    public void Executar_DeveInvocarCadaUmaDasCalculadorasUmaVezParaCadaFamilia()
    {
        var familias = FamiliaMock.CriarMultiplas(quantidade: 100);

        var familiasOrdenadas = _avaliador.Executar(familias);

        foreach (var familia in familias)
        {
            _calculadoraPontuacaoDependentes.Verify(c => c.Executar(familia), Times.Once);
            _calculadoraPontuacaoRenda.Verify(c => c.Executar(familia), Times.Once);
        }
    }
}
