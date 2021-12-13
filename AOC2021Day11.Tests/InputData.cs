using System.Collections.Generic;

namespace AOC2021Day11.Tests;

internal static class InputData
{
    internal static IList<string> GetSimpleData()
    {
        return new List<string>
        {
            "11111",
            "19991",
            "19191",
            "19991",
            "11111"
        };
    }
    internal static List<string> GetSampleData()
    {
        return new List<string>
        {
            "5483143223",
            "2745854711",
            "5264556173",
            "6141336146",
            "6357385478",
            "4167524645",
            "2176841721",
            "6882881134",
            "4846848554",
            "5283751526"
        };
    }

    internal static List<string> GetRealData()
    {
        return new List<string>
        {
            "8624818384",
            "3725473343",
            "6618341827",
            "4573826616",
            "8357322142",
            "6846358317",
            "7286886112",
            "8138685117",
            "6161124267",
            "3848415383"
        };
    }
}