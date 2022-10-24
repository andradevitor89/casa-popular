using Dominio;

namespace Mocks;

public static class FamiliaMock
{
    public static Familia Criar(int dependentes, int renda)
    {
        var membros = new List<Pessoa>()
        {
            new Pessoa(idade:30, renda),
            new Pessoa(idade:30, renda:0)
        };

        for (int i = 0; i < dependentes; i++)
        {
            membros.Add(new Pessoa(0, 0));
        }

        return new Familia(membros);
    }

    public static IEnumerable<Familia> CriarMultiplas(int quantidade)
    {
        var random = new Random();
        var familias = new List<Familia>();

        for (int i = 0; i < quantidade; i++)
        {
            var familia = Criar(dependentes: random.Next(0, 5),
                                renda: random.Next(0, 2000));
            familias.Add(familia);
        }

        return familias;
    }
}