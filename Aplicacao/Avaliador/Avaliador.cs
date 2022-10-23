using Dominio;

namespace Aplicacao;

public class Avaliador : IAvaliador
{
    private readonly List<ICalculadora> _calculadoras;

    public Avaliador(ICalculadoraPontuacaoRenda calculadoraPontuacaoRenda, ICalculadoraPontuacaoDependentes calculadoraPontuacaoDependentes)
    {
        _calculadoras = new List<ICalculadora>()
        {
            calculadoraPontuacaoRenda,
            calculadoraPontuacaoDependentes
        };
    }

    public IEnumerable<Familia> Executar(IEnumerable<Familia> familias)
    {
        foreach (var familia in familias)
        {
            var pontuacao = _calculadoras.Sum(c => c.Executar(familia));
            familia.Pontuacao = pontuacao;
        }

        return familias.OrderByDescending(familia => familia.Pontuacao);
    }
}