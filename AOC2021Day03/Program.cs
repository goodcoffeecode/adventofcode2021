using Microsoft.Extensions.DependencyInjection;
using AOC2021Common;

namespace AOC2021Day03;

public static class Program
{
    public async static Task Main()
    {
        var services = new ServiceCollection();

        services
            .AddSingleton(s => new TextFileInputOptions("..\\..\\..\\inputData.txt"))
            .AddSingleton<IJaggedBitArrayReader, JaggedBitArrayReader>()
            .AddSingleton<IStringListReader, TextFileStringListReader>()
            .AddSingleton<Part1Calculator>()
            .AddSingleton<Part2Calculator>()
            .AddScoped<Runner>();

        var provider = services.BuildServiceProvider();

        var runner = provider.GetService<Runner>();

        await runner.RunAsync();
    }
}