namespace AOC2021Day03;

internal class Part1Calculator
{
    internal class Output
    {
        private readonly IList<bool> _gamma = new List<bool>();
        private readonly IList<bool> _epsilon = new List<bool>();

        public void AddToGamma(bool val)
        {
            _gamma.Add(val);
            _epsilon.Add(!val);
        }

        public string GammaStr => _gamma.ConvertToString();
        public string EpsilonStr => _epsilon.ConvertToString();

        public int Power => _gamma.ConvertToInt32() * _epsilon.ConvertToInt32();

        public override string ToString()
        {
            return $"Gamma is {GammaStr}. Epsilon is {EpsilonStr}. Power is {Power}.";
        }
    }

    internal Output Calculate(bool[][] inputs)
    {
        var inputCols = inputs[0].Length;

        var output = new Output();

        for (int i = 0; i < inputCols; i++)
        {
            var mostPop = inputs.FindMostPopularBitInColumn(i);

            output.AddToGamma(mostPop);
        }

        return output;
    }
}