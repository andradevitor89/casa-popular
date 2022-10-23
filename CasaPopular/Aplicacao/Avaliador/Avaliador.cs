using Dominio;

namespace Aplicacao;

public class Avaliador : IAvaliador
{
    private readonly ICalculadora _calculadora;

    public Avaliador(ICalculadora calculadora)
    {
        _calculadora = calculadora;
    }

    public void Executar(Familia familia)
    {
        var pontuacao = _calculadora.Executar(familia);
        familia.Pontuacao = pontuacao;
    }
}

