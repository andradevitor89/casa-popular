using Dominio;

namespace Aplicacao;

public class Calculadora : ICalculadora
{
    private readonly List<ICalculadora> _calculadoras;

    public Calculadora(ICalculadoraPontuacaoRenda calculadoraPontuacaoRenda, ICalculadoraPontuacaoDependentes calculadoraPontuacaoDependentes)
    {
        _calculadoras = new List<ICalculadora>()
        {
            calculadoraPontuacaoRenda,
            calculadoraPontuacaoDependentes
        };
    }

    public int Executar(Familia familia)
    {
        return _calculadoras.Sum(c => c.Executar(familia));
    }
}

