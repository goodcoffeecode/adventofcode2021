using System.Collections.Generic;

namespace AOC2021Day12.Tests;

internal static class InputData
{   
    internal static List<string> GetSimpleData()
    {
        return new List<string>
        {
            "start-A",
            "start-b",
            "A-c",
            "A-b",
            "b-d",
            "A-end",
            "b-end"
        };
    }

    internal static List<string> GetSlightlyLargerData()
    {
        return new List<string>
        {
            "dc-end",
            "HN-start",
            "start-kj",
            "dc-start",
            "dc-HN",
            "LN-dc",
            "HN-end",
            "kj-sa",
            "kj-HN",
            "kj-dc"
        };
    }

    internal static List<string> GetEvenLargerData()
    {
        return new List<string>
        {
            "fs-end",
            "he-DX",
            "fs-he",
            "start-DX",
            "pj-DX",
            "end-zg",
            "zg-sl",
            "zg-pj",
            "pj-he",
            "RW-he",
            "fs-DX",
            "pj-RW",
            "zg-RW",
            "start-pj",
            "he-WI",
            "zg-he",
            "pj-fs",
            "start-RW"
        };
    }

    internal static List<string> GetSampleData()
    {
        return new List<string>
        {
            "fs-end",
            "he-DX",
            "fs-he",
            "start-DX",
            "pj-DX",
            "end-zg",
            "zg-sl",
            "zg-pj",
            "pj-he",
            "RW-he",
            "fs-DX",
            "pj-RW",
            "zg-RW",
            "start-pj",
            "he-WI",
            "zg-he",
            "pj-fs",
            "start-RW"
        };
    }

    internal static List<string> GetRealData()
    {
        return new List<string>
        {
            "pf-pk",
            "ZQ-iz",
            "iz-NY",
            "ZQ-end",
            "pf-gx",
            "pk-ZQ",
            "ZQ-dc",
            "NY-start",
            "NY-pf",
            "NY-gx",
            "ag-ZQ",
            "pf-start",
            "start-gx",
            "BN-ag",
            "iz-pf",
            "ag-FD",
            "pk-NY",
            "gx-pk",
            "end-BN",
            "ag-pf",
            "iz-pk",
            "pk-ag",
            "iz-end",
            "iz-BN"
        };
    }
}