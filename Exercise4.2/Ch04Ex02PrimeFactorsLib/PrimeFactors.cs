using System.Diagnostics.CodeAnalysis;

namespace Ch04Ex02PrimeFactorsLib
{
    public static class Ch04Ex02PrimeFactorsLib
    {
        public static string PrimeFactors(int number) => number switch
        {
            int n when n <= 0 => throw new ArgumentOutOfRangeException(nameof(number),$"The number {number} is not valid"),
            1 => "1",
            int n when n % 2 == 0 => "2x" + PrimeFactors(number / 2),
            int n when n % 3 == 0 => "3x" + PrimeFactors(number / 3),
            int n when n % 5 == 0 => "5x" + PrimeFactors(number / 5),
            _ => number.ToString()
        };
    }
}