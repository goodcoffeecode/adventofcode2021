namespace AOC2021Day12.Tests;

internal record class Edge(Node Start, Node End)
{
    internal static Edge Parse(string s, IDestinationValidator destinationValidator)
    {
        const char Split = '-';

        var split = s.Split(Split);

        return new Edge(new Node(destinationValidator, split[0]), new Node(destinationValidator, split[1]));
    }
}