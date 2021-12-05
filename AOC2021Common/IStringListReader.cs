namespace AOC2021Common;

public interface IStringListReader
{
    Task<List<string>> ReadAsStringListAsync();
}

public class TextFileStringListReader : IStringListReader
{
    private readonly string _fileName;

    public TextFileStringListReader(TextFileInputOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        _fileName = options.FileName;
    }

    public async Task<List<string>> ReadAsStringListAsync()
    {
        var values = new List<string>();

        using var sr = File.OpenText(_fileName);

        while (!sr.EndOfStream)
        {
            values.Add(await sr.ReadLineAsync());
        }

        sr.Close();

        return values;
    }
}