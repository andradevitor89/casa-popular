using Dominio;
using FluentAssertions;
using Xunit;

namespace Testes.Dominio;

public class FamiliaTeste
{
    [Fact]
    public void Membros_DevemSerExatamenteIguaisAosPassadosParaOConstrutor()
    {
        var membros = new[]
        {
            new Pessoa(idade:0, renda:0),
            new Pessoa(idade:12, renda:0),
            new Pessoa(idade:20, renda:0),
            new Pessoa(idade:30, renda:1000),
            new Pessoa(idade:35, renda:200)
        };

        var familia = new Familia(membros);

        familia.Membros.Should().Equal(membros);
    }

    [Fact]
    public void Renda_DeveSerASomaDaRendaDosMembros()
    {
        var membros = new[]
        {
            new Pessoa(idade:0, renda:0),
            new Pessoa(idade:12, renda:0),
            new Pessoa(idade:20, renda:0),
            new Pessoa(idade:30, renda:1000),
            new Pessoa(idade:35, renda:200)
        };

        var familia = new Familia(membros);

        familia.Renda.Should().Be(1200);
    }

    [Fact]
    public void QuantidadeDependentes_DeveSerAQuantidadeDeMembrosComAteDezoitoAnos()
    {
        var membros = new[]
        {
            new Pessoa(idade:0, renda:0),
            new Pessoa(idade:12, renda:0),
            new Pessoa(idade:20, renda:0),
            new Pessoa(idade:30, renda:1000),
            new Pessoa(idade:35, renda:200)
        };

        var familia = new Familia(membros);

        familia.QuantidadeDependentes.Should().Be(2);
    }
}