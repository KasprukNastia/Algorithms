using static ClimbingStairs.Program;

namespace ClimbingStairs;

internal class Program
{
    static void Main(string[] args)
    {
        var solution = new Solution();

        Console.WriteLine(solution.ClimbStairs(35));
    }

    public class Solution
    {
        private readonly Factorial _factorial = new ();

        public int ClimbStairs(int n)
        {
            int twoCount = n / 2;
            int oneCount = n % 2;

            long result = 0, preCalculated = 0;
            int bigger, smaller;
            while (twoCount >= 0)
            {
                bigger = twoCount;
                smaller = oneCount;
                if (oneCount > twoCount)
                {
                    bigger = oneCount;
                    smaller = twoCount;
                }

                if (preCalculated == 0)
                {
                    preCalculated = bigger + 1;
                    for (int i = bigger + 2; i <= twoCount + oneCount; i++)
                    {
                        preCalculated *= i;
                    }
                }
                else
                {
                    preCalculated *= bigger + 1;
                    preCalculated *= twoCount + oneCount;
                }
                result += preCalculated / _factorial.Calculate(smaller);
                twoCount--;
                oneCount += 2;
            }

            return (int)result;
        }

        public class Factorial
        {
            private readonly long[] _preCalculated = new long[46];
            private int _lastCalculated = 1;

            public Factorial()
            {
                _preCalculated[0] = 1;
                _preCalculated[1] = 1;
            }

            public long Calculate(int num)
            {
                if (_preCalculated[num] != 0)
                    return _preCalculated[num];

                long result = _preCalculated[_lastCalculated];
                for (int i = _lastCalculated + 1; i <= num; i++)
                {
                    result *= i;
                    _preCalculated[i] = result;
                }

                _lastCalculated = num;

                return result;
            }
        }
    }
}