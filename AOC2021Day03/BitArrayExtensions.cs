namespace AOC2021Day03;

public static class BitArrayExtensions
{
    public static bool FindMostPopularBitInColumn(this bool[][] inputs, int columnPos)
    {
        var falseCount = 0;
        var trueCount = 0;

        for (int i = 0; i < inputs.Length; i++)
        {
            var bit = inputs[i][columnPos];

            if (bit)
            {
                trueCount++;
            }
            else
            {
                falseCount++;
            }
        }

        if (falseCount == trueCount)
        {
            return true;
        }

        if (falseCount > trueCount)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public static bool FindLeastPopularBitInColumn(this bool[][] inputs, int columnPos)
    {
        var falseCount = 0;
        var trueCount = 0;

        for (int i = 0; i < inputs.Length; i++)
        {
            var bit = inputs[i][columnPos];

            if (bit)
            {
                trueCount++;
            }
            else
            {
                falseCount++;
            }
        }

        if (falseCount == trueCount)
        {
            return false;
        }

        if (falseCount < trueCount)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}