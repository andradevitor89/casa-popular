using Aplicacao;
using FluentAssertions;
using Mocks;
using Xunit;

namespace Testes.Aplicacao;

public class CalculadoraPontuacaoRendaTeste
{
    private readonly ICalculadoraPontuacaoRenda _calculadora;

    public CalculadoraPontuacaoRendaTeste()
    {
        _calculadora = new CalculadoraPontuacaoRenda();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(450)]
    [InlineData(900)]
    public void Executar_QuandoFamiliaTemRendaDeAte900_DeveRetornarCincoPontos(int renda)
    {
        var familia = FamiliaMock.Criar(dependentes: 0, renda);
        var pontuacao = _calculadora.Executar(familia);
        pontuacao.Should().Be(5);
    }

    [Theory]
    [InlineData(901)]
    [InlineData(1200)]
    [InlineData(1500)]
    public void Executar_QuandoFamiliaTemRendaMaiorQueNovescentosMasMenorQueMilEQuinhentos_DeveRetornarTresPontos(int renda)
    {
        var familia = FamiliaMock.Criar(dependentes: 0, renda);
        var pontuacao = _calculadora.Executar(familia);
        pontuacao.Should().Be(3);
    }

    [Theory]
    [InlineData(1501)]
    [InlineData(2000)]
    public void Executar_QuandoFamiliaTemRendaMaiorQueMilEQuinhentos_DeveRetornarZeroPontos(int renda)
    {
        var familia = FamiliaMock.Criar(dependentes: 0, renda);
        var pontuacao = _calculadora.Executar(familia);
        pontuacao.Should().Be(0);
    }
}
