using Dominio;

namespace Aplicacao;
public interface IOrdenador
{
    IEnumerable<Familia> Executar(IEnumerable<Familia> familias);
}