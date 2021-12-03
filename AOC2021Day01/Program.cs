using AOC2021Common;
using Microsoft.Extensions.DependencyInjection;

namespace AOC2021Day01;

public static class Program
{
    public async static Task Main()
    {
        var services = new ServiceCollection();

        services
            .AddSingleton(s => new TextFileInputOptions("..\\..\\..\\inputData.txt"))
            .AddSingleton<IInt32ListReader, TextFileInt32ListReader>()
            .AddSingleton<SingleDayIncreaseCounter>()
            .AddSingleton<ThreeDayIncreaseCounter>()
            .AddScoped<Runner>();

        var provider = services.BuildServiceProvider();

        var runner = provider.GetService<Runner>();

        await runner.RunAsync();
    }
}