namespace AOC2021Day05;

internal class Grid
{
    private readonly Dictionary<Coordinate, int> _coords = new Dictionary<Coordinate, int>();

    public void AddLine(Line line)
    {
        var coords = line.GetAllIntergerCoordinates();

        foreach (var coord in coords)
        {
            if (_coords.ContainsKey(coord))
            {
                _coords[coord]++;
            }
            else
            {
                _coords.Add(coord, 1);
            }
        }
    }

    public int CountNumberOfPointsWithAtleastThisNumberOfHits(int hits)
    {
        var matching = _coords.Where(c => c.Value >= hits);

        return matching.Count();
    }
}