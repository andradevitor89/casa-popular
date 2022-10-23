using Dominio;

namespace Testes;


public static class PessoaMock
{
    public static Pessoa Criar()
    {
        var random = new Random();
        return new Pessoa(idade: random.Next(0, 100),
                          renda: random.Next(0, 1000));
    }
}