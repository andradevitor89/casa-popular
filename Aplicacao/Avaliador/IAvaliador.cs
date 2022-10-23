using Dominio;

namespace Aplicacao;

public interface IAvaliador
{
    IEnumerable<Familia> Executar(IEnumerable<Familia> familias);
}