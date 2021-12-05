using AOC2021Common;
using Microsoft.Extensions.DependencyInjection;

namespace AOC2021Day04;

public static class Program
{
    public async static Task Main()
    {
        var services = new ServiceCollection();

        services
            .AddSingleton(s => new TextFileInputOptions("..\\..\\..\\inputData.txt"))
            .AddSingleton<IStringYieldingReader, TextFileStringYieldingReader>()
            .AddSingleton<BingoGame>()
            .AddSingleton<Runner>();

        var provider = services.BuildServiceProvider();

        var runner = provider.GetService<Runner>();

        await runner.RunAsync();
    }
}