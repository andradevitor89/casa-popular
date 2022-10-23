namespace Dominio;

public class Pessoa
{
    public Pessoa(int idade, int renda)
    {
        Idade = idade;
        Renda = renda;
    }

    public int Idade { get; private set; }
    public int Renda { get; private set; }
    public bool Dependente => Idade <= 18;

}