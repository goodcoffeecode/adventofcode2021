using System;
using System.Text;

namespace AOC2021Day12.Tests;

public class Path
{
    private const char Sep = ',';

    private readonly StringBuilder _path = new();

    internal Guid Id { get; init; } = Guid.NewGuid();

    internal Path()
    {
    }

    internal Path(Path pathToBranchFrom)
    {
        _path.Append(pathToBranchFrom.ToString());
    }

    internal void Add(Node node)
    {
        if (_path.Length > 0)
        {
            _path.Append(Sep);
        }

        _path.Append(node.Name);
    }

    public override string ToString() => _path.ToString();
}
