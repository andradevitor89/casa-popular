using Dominio;

namespace Aplicacao;

public class Ordenador : IOrdenador
{
    private readonly IAvaliador _avaliador;

    public Ordenador(IAvaliador avaliador)
    {
        _avaliador = avaliador;
    }

    public IEnumerable<Familia> Executar(IEnumerable<Familia> familias)
    {
        familias.ToList()
                .ForEach(_avaliador.Executar);

        return familias.OrderByDescending(familia => familia.Pontuacao);
    }
}

