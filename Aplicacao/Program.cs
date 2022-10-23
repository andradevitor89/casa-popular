using System.Diagnostics.CodeAnalysis;
using Aplicacao;
using Microsoft.Extensions.DependencyInjection;
using Mocks;

[ExcludeFromCodeCoverage]
internal class Program
{
    private static void Main()
    {
        var avaliador = InstanciarAvaliador();
        var familias = FamiliaMock.CriarMultiplas(quantidade: 10000);
        var familiasOrdenadas = avaliador!.Executar(familias);

        File.WriteAllLines("resultado", familiasOrdenadas.Select(f => $"Pontuação: {f.Pontuacao} - Renda: {f.Renda} - Dependentes: {f.QuantidadeDependentes}"));
    }

    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ICalculadoraPontuacaoRenda, CalculadoraPontuacaoRenda>();
        services.AddScoped<ICalculadoraPontuacaoDependentes, CalculadoraPontuacaoDependentes>();
        services.AddScoped<IAvaliador, Avaliador>();
    }

    private static IAvaliador InstanciarAvaliador()
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        return serviceCollection.BuildServiceProvider().GetService<IAvaliador>();
    }
}