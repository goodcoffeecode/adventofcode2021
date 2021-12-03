namespace AOC2021Common;

public interface IInputDataReader
{
    Task<IList<int>> ReadAsInt32ListAsync();
    Task<IList<string>> ReadAsStringAsync();
}

public record class TextFileInputOptions(string FileName);

public class TextFileInputReader : IInputDataReader
{
    private readonly string _fileName;

    public TextFileInputReader(TextFileInputOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        _fileName = options.FileName;
    }

    public async Task<IList<int>> ReadAsInt32ListAsync()
    {
        var data = new List<int>();

        using (var sr = File.OpenText(_fileName))
        {
            while (!sr.EndOfStream)
            {
                data.Add(Convert.ToInt32(await sr.ReadLineAsync()));
            }

            sr.Close();
        }

        return data;
    }

    public async Task<IList<string>> ReadAsStringAsync()
    {
        var values = new List<string>();

        using (var sr = File.OpenText(_fileName))
        {
            while (!sr.EndOfStream)
            {
                values.Add(await sr.ReadLineAsync());
            }

            sr.Close();
        }

        return values;
    }
}