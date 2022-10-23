using Dominio;

namespace Aplicacao;

public class CalculadoraPontuacaoRenda : ICalculadoraPontuacaoRenda
{
    public int Executar(Familia familia)
    {
        if (familia.Renda <= 900) return 5;
        else if (familia.Renda <= 1500) return 3;
        else return 0;
    }
}
