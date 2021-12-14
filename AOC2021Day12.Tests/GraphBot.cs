using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2021Day12.Tests;

internal class GraphBot
{
    private readonly IList<Node> _nodes = new List<Node>();

    internal GraphBot(IList<Node> nodes)
    {
        ArgumentNullException.ThrowIfNull(nodes);

        _nodes = nodes;
    }

    internal IList<Path> Walk()
    {
        var startingNode = GetStartingNode();

        if (startingNode == null)
        {
            throw new InvalidOperationException("Could not find a starting node!");
        }

        return Walk(new Path(), startingNode);
    }

    private List<Path> Walk(Path path, Node currentNode)
    {
        path.Add(currentNode);

        if (currentNode.GetIsEnd())
        {
            return new List<Path> { path };
        }

        var destinations = currentNode.GetValidDestinations(path);

        var pathsToReturn = new List<Path>();

        foreach (var node in destinations)
        {
            pathsToReturn.AddRange(Walk(new Path(path), node));
        }

        return pathsToReturn;
    }

    private Node? GetStartingNode() => _nodes.FirstOrDefault(n => n.GetIsStart());
}