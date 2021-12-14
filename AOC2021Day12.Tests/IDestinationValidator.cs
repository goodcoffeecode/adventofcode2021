namespace AOC2021Day12.Tests;

public interface IDestinationValidator
{
    bool IsValid(Path path, Node node);
}

internal class Part1DestinationValidator : IDestinationValidator
{
    public bool IsValid(Path path, Node node)
    {
        return !node.GetIsSmall() || !path.ToString().Contains(node.Name);
    }
}

internal class Part2DestinationValidator : IDestinationValidator
{
    public static string SmallCaveToVisitTwice { get; set; }

    public bool IsValid(Path path, Node node)
    {
        // Big caves can be visited any number of times
        if (node.GetIsBig())
        {
            return true;
        }

        // Can't go back to the start
        if (node.GetIsStart())
        {
            return false;
        }

        if (node.Name == SmallCaveToVisitTwice)
        {
            var ret = path.ToString().IndexOf(node.Name) == path.ToString().LastIndexOf(node.Name);

            if (!ret)
            {
                System.Console.Write("");
            }

            return ret;
        }

        // Small caves can be visited at most once
        return !path.ToString().Contains(node.Name);
    }
}