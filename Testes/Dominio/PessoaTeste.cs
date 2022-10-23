using System.Collections;
using Dominio;
using FluentAssertions;
using Xunit;

namespace Testes.Dominio;

public class PessoaTeste
{
    [Theory]
    [ClassData(typeof(PessoasDeZeroADezoitoAnos))]
    public void Dependente_DeveSerVerdadeiroParaPessoaComAteDezoitoAnos(Pessoa pessoa)
    {
        pessoa.Dependente.Should().BeTrue();
    }

    [Theory]
    [ClassData(typeof(PessoasComMaisDeDezoitoAnos))]
    public void Membros_DevemSerExatamenteIguaisAosPassadosParaOConstrutor(Pessoa pessoa)
    {
        pessoa.Dependente.Should().BeFalse();
    }

    [Fact]
    public void Idade_DevemSerExatamenteIgualAPassadaParaOConstrutor()
    {
        var pessoa = new Pessoa(idade: 10, renda: 0);
        pessoa.Idade.Should().Be(10);
    }

    [Fact]
    public void Renda_DevemSerExatamenteIgualAPassadaParaOConstrutor()
    {
        var pessoa = new Pessoa(idade: 35, renda: 850);
        pessoa.Renda.Should().Be(850);
    }
}

public class PessoasDeZeroADezoitoAnos : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        for (int idade = 0; idade <= 18; idade++)
        {
            yield return new object[] { new Pessoa(idade, renda: 0) };
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class PessoasComMaisDeDezoitoAnos : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        for (int idade = 19; idade <= 100; idade++)
        {
            yield return new object[] { new Pessoa(idade, renda: 0) };
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
