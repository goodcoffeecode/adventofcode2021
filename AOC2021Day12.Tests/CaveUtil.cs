using System.Collections.Generic;
using System.Linq;

namespace AOC2021Day12.Tests;

internal class CaveUtil
{
    private readonly Dictionary<string, Node> _nodes = new();
    private readonly List<Edge> _edges = new();

    internal IList<Node> GetNodes() => _nodes.Select(n => n.Value).ToList();

    internal CaveUtil(IList<string> data, IDestinationValidator destinationValidator)
    {
        ExtractNodesAndEdges(data, destinationValidator);
        ConnectNodes();
    }

    private void ExtractNodesAndEdges(IList<string> data, IDestinationValidator destinationValidator)
    {
        foreach (var line in data)
        {
            var edge = Edge.Parse(line, destinationValidator);

            _edges.Add(edge);

            _nodes.TryAdd(edge.Start.Name, edge.Start);
            _nodes.TryAdd(edge.End.Name, edge.End);
        }
    }

    private void ConnectNodes()
    {
        foreach (var node in _nodes.Select(n => n.Value))
        {
            var destinationNames = _edges.Where(e => e.Start.Name == node.Name).Select(e => e.End.Name).ToList();
            destinationNames.AddRange(_edges.Where(e => e.End.Name == node.Name).Select(e => e.Start.Name));

            foreach (var destinationName in destinationNames)
            {
                node.AddDestination(_nodes[destinationName]);
            }
        }
    }
}