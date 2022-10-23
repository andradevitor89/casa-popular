using Aplicacao;
using Dominio;

namespace Testes;

public static class FamiliaMock
{
    public static Familia Criar()
    {
        var membros = new[]
        {
            PessoaMock.Criar(),
            PessoaMock.Criar(),
            PessoaMock.Criar()
        };
        return new Familia(membros);
    }
}