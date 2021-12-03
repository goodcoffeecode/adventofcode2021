namespace AOC2021Day02;

internal class Part1Calculator
{
    internal class Output
    {
        internal int Position { get; set; } = 0;
        internal int Depth { get; set; } = 0;
        internal string Location { get => $"({Position}, {Depth})"; }
        internal int Vector { get => Position * Depth; }

        public override string ToString()
        {
            return $"Final position and depth are {Location}. Vector is {Vector}.";
        }
    }

    internal Output Calculate(IList<string> inputs)
    {
        var output = new Output();

        const string Up = "up";
        const string Down = "down";
        const string Forward = "forward";

        foreach (var input in inputs)
        {
            var split = input.Split(' ');

            if (split.Length != 2)
            {
                throw new Exception($"I expected 2 segments for '{input}', but I only found {split.Length}.");
            }

            var direction = split[0];
            var units = Convert.ToInt32(split[1]);

            switch (direction)
            {
                case Up:
                    output.Depth -= units;
                    break;
                case Down:
                    output.Depth += units;
                    break;
                case Forward:
                    output.Position += units;
                    break;
                default:
                    throw new ArgumentException($"I didn't recognise '{split[0]}' as a valid instruction");
            }
        }

        return output;
    }
}