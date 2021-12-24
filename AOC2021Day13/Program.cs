namespace AOC2021Day13;

public static class Program
{
    public static async Task Main()
    {
        var data = await InputData.GetDataAsync("..\\..\\..\\realInput.txt");

        var points = data.Item1;
        var folds = data.Item2;

        var paper = new Paper(points);

        Console.WriteLine("Day 13, Part 2.......");

        Gap();

        foreach (var fold in folds)
        {
            paper.Fold(fold);
        }

        // FJAHJGAH
        paper.Output();
    }

    private static void Gap()
    {
        Console.WriteLine("");
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("");
    }
}