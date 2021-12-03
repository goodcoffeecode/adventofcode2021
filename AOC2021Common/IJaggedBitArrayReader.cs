namespace AOC2021Common;

public interface IJaggedBitArrayReader
{
    Task<bool[][]> ReadAsJaggedBitArrayAsync();
}

public class JaggedBitArrayReader : IJaggedBitArrayReader
{
    private readonly IStringListReader _stringListReader;

    public JaggedBitArrayReader(IStringListReader stringListReader)
    {
        ArgumentNullException.ThrowIfNull(stringListReader);

        _stringListReader = stringListReader;
    }

    public async Task<bool[][]> ReadAsJaggedBitArrayAsync()
    {
        var stringArray = await _stringListReader.ReadAsStringListAsync();

        var rows = stringArray.Count;

        var values = new bool[rows][];

        for (int i = 0; i < stringArray.Count; i++)
        {
            var row = new bool[stringArray[i].Length];

            for (int j = 0; j < stringArray[i].Length; j++)
            {
                row[j] = stringArray[i][j] == '1';

                values[i] = row;
            }
        }

        return values;
    }
}