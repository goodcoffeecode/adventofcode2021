using AOC2021Common;
using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;

namespace AOC2021Day15.Tests;

internal class DijkstraCave : Cave
{
    private readonly Graph<int, int> _graph = new();

    internal DijkstraCave(int[,] matrix)
        : base(matrix)
    {
        var width = matrix.GetColCount();
        var height = matrix.GetRowCount();

        for (int i = 0; i < width * height; i++)
        {
            _graph.AddNode(i);
        }

        uint oneBasedPos1;
        uint oneBasedPos2;

        var edgeCount = 0;

        for (var row = 0; row < height; row++)
        {
            for (var col = 0; col < width; col++)
            {
                oneBasedPos1 = (uint)((row * width) + col + 1);

                // Horizontal...
                if (col < width - 1)
                {
                    _graph.Connect(oneBasedPos1, oneBasedPos1 + 1, matrix[row, col + 1], 0);
                    edgeCount++;

                    // Let's also reciprocate...
                    _graph.Connect(oneBasedPos1 + 1, oneBasedPos1, matrix[row, col], 0);
                    edgeCount++;
                }

                if (row < height - 1)
                {
                    oneBasedPos2 = (uint)(((row + 1) * width) + col + 1);

                    // Vertical...
                    _graph.Connect(oneBasedPos1, oneBasedPos2, matrix[row + 1, col], 0);
                    edgeCount++;

                    // Let's also reciprocate...
                    _graph.Connect(oneBasedPos2, oneBasedPos1, matrix[row, col], 0);
                    edgeCount++;
                }
            }
        }
    }

    internal override int FindShortestPath()
    {
        var result = DijkstraExtensions.Dijkstra(_graph, 1, (uint)_graph.NodesCount);

        return result.Distance;
    }
}