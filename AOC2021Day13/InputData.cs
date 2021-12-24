namespace AOC2021Day13;

internal static class InputData
{
    internal static async Task<Tuple<IList<Point>, IList<Fold>>> GetDataAsync(string fileName)
    {
        var reader = new AOC2021Common.TextFileStringListReader(new AOC2021Common.TextFileInputOptions(FileName: fileName));

        var allLines = (await reader.ReadAsStringListAsync()).Where(l => !string.IsNullOrEmpty(l));

        var points = allLines.Where(l => !l.StartsWith("fold")).Select(l =>
        {
            var split = l.Split(',');

            return new Point(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]));
        }).ToList();
        var folds = allLines.Where(l => l.StartsWith("fold")).Select(l =>
        {
            var split = l.Split('=');

            return new Fold(split[0].Last(), Convert.ToInt32(split[1]));
        }).ToList();

        return new Tuple<IList<Point>, IList<Fold>>(points, folds);
    }
}