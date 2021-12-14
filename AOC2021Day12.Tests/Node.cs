using System.Collections.Generic;
using System.Linq;

namespace AOC2021Day12.Tests;

public class Node
{
    private const string Start = "START";
    private const string End = "END";

    private readonly List<Node> _destinations = new();

    private readonly IDestinationValidator _destinationValidator;

    internal Node(IDestinationValidator destinationValidator, string name)
    {
        _destinationValidator = destinationValidator;
        Name = name;
    }

    internal string Name { get; init; }
    internal bool GetIsSmall() => Name.ToLower() == Name;
    internal bool GetIsBig() => !GetIsSmall();
    internal bool GetIsStart() => Name.ToUpper() == Start;
    internal bool GetIsEnd() => Name.ToUpper() == End;
    internal bool GetIsValidDestination(Path path) => _destinationValidator.IsValid(path, this);

    internal void AddDestination(Node destination) => _destinations.Add(destination);

    internal List<Node> GetValidDestinations(Path path) => _destinations.Where(d => d.GetIsValidDestination(path)).ToList();

    public override string ToString() => $"{Name} ({_destinations.Count} destinations)";
}