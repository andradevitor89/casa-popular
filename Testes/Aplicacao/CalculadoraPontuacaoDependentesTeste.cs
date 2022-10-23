using Aplicacao;
using Dominio;
using FluentAssertions;
using Xunit;

namespace Testes.Aplicacao;

public class CalculadoraPontuacaoDependentesTeste
{
    private readonly ICalculadoraPontuacaoDependentes _calculadora;

    public CalculadoraPontuacaoDependentesTeste()
    {
        _calculadora = new CalculadoraPontuacaoDependentes();
    }

    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void Executar_QuandoFamiliaTemTresOuMaisDependentes_DeveRetornarTresPontos(int quantidadeDependentes)
    {
        var membros = new List<Pessoa>();
        for (int i = 0; i < quantidadeDependentes; i++)
        {
            membros.Add(new Pessoa(idade: 0, renda: 0));
        }
        var familia = new Familia(membros);
        var pontuacao = _calculadora.Executar(familia);
        pontuacao.Should().Be(3);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void Executar_QuandoFamiliaTemUmOuDoisDependentes_DeveRetornarDoisPontos(int quantidadeDependentes)
    {
        var membros = new List<Pessoa>();
        for (int i = 0; i < quantidadeDependentes; i++)
        {
            membros.Add(new Pessoa(idade: 0, renda: 0));
        }
        var familia = new Familia(membros);
        var pontuacao = _calculadora.Executar(familia);
        pontuacao.Should().Be(2);
    }

    [Fact]
    public void Executar_QuandoFamiliaNaoTemDependentes_DeveRetornarZeroPontos()
    {
        var membros = new List<Pessoa>();
        var familia = new Familia(membros);
        var pontuacao = _calculadora.Executar(familia);
        pontuacao.Should().Be(0);
    }
}
