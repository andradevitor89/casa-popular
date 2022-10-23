namespace Dominio;

public class Familia
{
    public Familia(IEnumerable<Pessoa> membros)
    {
        Membros = membros;
    }

    public IEnumerable<Pessoa> Membros { get; private set; } = new List<Pessoa>();
    public int Renda => Membros.Sum(membro => membro.Renda);

    public int QuantidadeDependentes
    {
        get
        {
            return Membros.Where(membro => membro.Dependente).Count();
        }
    }

    public int Pontuacao { get; set; }
}