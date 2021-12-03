namespace AOC2021Day03;

internal class Part2Calculator
{
    internal class Output
    {
        public bool[] OxygenGeneratorRatingArray { get; set; }
        public bool[] CO2ScrubberRatingArray { get; set; }

        public int OxygenGeneratorRating { get => OxygenGeneratorRatingArray.ConvertToInt32(); }

        public int CO2ScrubberRating { get => CO2ScrubberRatingArray.ConvertToInt32(); }

        public int LifeSupportRating { get => OxygenGeneratorRating * CO2ScrubberRating; }

        public override string ToString()
        {
            return $"Oxygen Generator is at {OxygenGeneratorRatingArray.ConvertToString()} or {OxygenGeneratorRating}. CO2 Scrubber is at {CO2ScrubberRatingArray.ConvertToString()} or {CO2ScrubberRating}. Life support rating is {LifeSupportRating}.";
        }
    }

    internal Output Calculate(bool[][] inputs)
    {
        return new Output
        {

            OxygenGeneratorRatingArray = FilterBaseOnMostCommon(inputs).Single(),
            CO2ScrubberRatingArray = FilterBaseOnLeastCommon(inputs).Single()
        };
    }

    private static bool[][] FilterBaseOnMostCommon(bool[][] inputs, int pos = 0)
    {
        var mostCommon = inputs.FindMostPopularBitInColumn(pos);

        var filteredList = inputs.Where(i => i[pos] == mostCommon).ToArray();

        if (filteredList.Length == 1)
        {
            return filteredList;
        }
        else
        {
            return FilterBaseOnMostCommon(filteredList, pos + 1);
        }
    }

    private static bool[][] FilterBaseOnLeastCommon(bool[][] inputs, int pos = 0)
    {
        var mostCommon = inputs.FindLeastPopularBitInColumn(pos);

        var filteredList = inputs.Where(i => i[pos] == mostCommon).ToArray();

        if (filteredList.Length == 1)
        {
            return filteredList;
        }
        else
        {
            return FilterBaseOnLeastCommon(filteredList, pos + 1);
        }
    }
}