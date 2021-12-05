namespace AOC2021Common;

public interface IInt32ListReader
{
    Task<List<int>> ReadAsInt32ListAsync();
}

public class TextFileInt32ListReader : IInt32ListReader
{
    private readonly string _fileName;

    public TextFileInt32ListReader(TextFileInputOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        _fileName = options.FileName;
    }

    public async Task<List<int>> ReadAsInt32ListAsync()
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
}