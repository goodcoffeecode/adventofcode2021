namespace AOC2021Day04;

internal class BingoCell
{
    internal BingoCell(int number)
    {
        Number = number;
    }

    internal int Number { get; init; }

    internal bool IsSelected { get; private set; }

    internal void CheckNumber(int number)
    {
        if (Number == number)
        {
            IsSelected = true;
        }
    }
}