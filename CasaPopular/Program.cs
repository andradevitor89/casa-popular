using Aplicacao;
using Dominio;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        var ordenador = serviceCollection.BuildServiceProvider().GetService<IOrdenador>();

        var familias = new List<Familia>
        {
            // FamiliaMock.Criar(),
            // FamiliaMock.Criar(),
            // FamiliaMock.Criar(),
            // FamiliaMock.Criar(),
            // FamiliaMock.Criar(),
            // FamiliaMock.Criar(),
            // FamiliaMock.Criar()
        };
        var familiasOrdenadas = ordenador!.Executar(familias);
        Console.WriteLine(string.Join("\n", familiasOrdenadas.Select(f => $"Renda: {f.Renda} - Dependentes: {f.QuantidadeDependentes}")));
    }

    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ICalculadoraPontuacaoRenda, CaluladoraPontuacaoRenda>();
        services.AddScoped<ICalculadoraPontuacaoDependentes, CalculadoraPontuacaoDependentes>();
        services.AddScoped<ICalculadora, Calculadora>();
        services.AddScoped<IAvaliador, Avaliador>();
        services.AddScoped<IOrdenador, Ordenador>();
    }
}