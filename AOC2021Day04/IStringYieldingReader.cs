using AOC2021Common;

namespace AOC2021Day04;

internal interface IStringYieldingReader
{
    IAsyncEnumerable<string?> YieldStringsAsync();
}

internal class TextFileStringYieldingReader : IStringYieldingReader
{
    private readonly string _fileName;

    public TextFileStringYieldingReader(TextFileInputOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        _fileName = options.FileName;
    }

    public async IAsyncEnumerable<string?> YieldStringsAsync()
    {
        using var sr = File.OpenText(_fileName);

        while (!sr.EndOfStream)
        {
            yield return await sr.ReadLineAsync();
        }

        sr.Close();
    }
}
