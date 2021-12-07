namespace AOC2021Day06;

internal static class LanternFishVisitor
{
    internal static Dictionary<int, long> VisitForADay(Dictionary<int, long> fish)
    {
        const int NewFishCounter = 8;
        const int FishResetCounter = 6;
        const int ReadyToSpawnCounter = 0;

        long newFish = 0;

        if (fish.ContainsKey(ReadyToSpawnCounter))
        {
            newFish = fish[ReadyToSpawnCounter];
        }

        var newDictionary = new Dictionary<int, long>();

        for (var i = 1; i <= NewFishCounter; i++)
        {
            if (fish.ContainsKey(i))
            {
                newDictionary.Add(i - 1, fish[i]);
            }
        }

        if (newFish > 0)
        {
            newDictionary.Add(NewFishCounter, newFish);

            if (newDictionary.ContainsKey(FishResetCounter))
            {
                newDictionary[FishResetCounter] += newFish;
            }
            else
            {
                newDictionary.Add(FishResetCounter, newFish);
            }
        }

        return newDictionary;
    }
}