namespace AOC2021Day08.Tests
{
    internal static class DisplayValidator
    {
        private static readonly char[] Chars = new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };

        internal static bool IsZero(string s)
        {
            if (s.Length != 6)
            {
                return false;
            }

            return s.ContainsAllCharacter('a', 'b', 'c', 'e', 'f', 'g');
        }

        internal static bool IsOne(string s)
        {
            if (s.Length != 2)
            {
                return false;
            }

            return s.ContainsAllCharacter('c', 'f');
        }

        internal static bool IsTwo(string s)
        {
            if (s.Length != 5)
            {
                return false;
            }

            return s.ContainsAllCharacter('a', 'c', 'd', 'e', 'g');
        }

        internal static bool IsThree(string s)
        {
            if (s.Length != 5)
            {
                return false;
            }

            return s.ContainsAllCharacter('a', 'c', 'd', 'f', 'g');
        }

        internal static bool IsFour(string s)
        {
            if (s.Length != 4)
            {
                return false;
            }

            return s.ContainsAllCharacter('b', 'c', 'd', 'f');
        }

        internal static bool IsFive(string s)
        {
            if (s.Length != 5)
            {
                return false;
            }

            return s.ContainsAllCharacter('a', 'b', 'd', 'f', 'g');
        }

        internal static bool IsSix(string s)
        {
            if (s.Length != 6)
            {
                return false;
            }

            return s.ContainsAllCharacter('a', 'b', 'd', 'e', 'f', 'g');
        }

        internal static bool IsSeven(string s)
        {
            if (s.Length != 3)
            {
                return false;
            }

            return s.ContainsAllCharacter('a', 'c', 'f');
        }

        internal static bool IsEight(string s)
        {
            if (s.Length != 7)
            {
                return false;
            }

            return s.ContainsAllCharacter(Chars);
        }

        internal static bool IsNine(string s)
        {
            if (s.Length != 6)
            {
                return false;
            }

            return s.ContainsAllCharacter('a', 'b', 'c', 'd', 'f', 'g');
        }
    }
}