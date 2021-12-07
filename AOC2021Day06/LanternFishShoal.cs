using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2021Day06
{
    internal class LanternFishShoal
    {
        private Dictionary<int, long> _fish;

        internal LanternFishShoal(Dictionary<int, long> fish)
        {
            ArgumentNullException.ThrowIfNull(fish);

            _fish = fish;
        }

        internal LanternFishShoal(string commaSeparatedString)
            : this(commaSeparatedString.Split(',').Select(i => int.Parse(i)).ToList())
        {
        }

        internal LanternFishShoal(IList<int> fish)
            : this(ConvertListToDictionary(fish))
        {
        }

        internal long Model(int totalDays)
        {
            for (int i = 0; i < totalDays; i++)
            {
                _fish = LanternFishVisitor.VisitForADay(_fish);
            }

            return CountFish(_fish);
        }

        private static long CountFish(Dictionary<int, long> fish) => fish.Sum(f => f.Value);

        private static Dictionary<int, long> ConvertListToDictionary(IList<int> input)
        {
            var result = new Dictionary<int, long>();

            for (int i = 0; i < input.Count; i++)
            {
                if (result.ContainsKey(input[i]))
                {
                    result[input[i]]++;
                }
                else
                {
                    result.Add(input[i], 1);
                }
            }

            return result;
        }
    }
}