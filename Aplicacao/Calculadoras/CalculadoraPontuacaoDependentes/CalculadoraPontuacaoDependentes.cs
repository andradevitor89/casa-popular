using Dominio;

namespace Aplicacao;

public class CalculadoraPontuacaoDependentes : ICalculadoraPontuacaoDependentes
{
    public int Executar(Familia familia)
    {
        if (familia.QuantidadeDependentes >= 3) return 3;
        else if (familia.QuantidadeDependentes > 0) return 2;
        else return 0;
    }
}