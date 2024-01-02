using static Ch04Ex02PrimeFactorsLib.Ch04Ex02PrimeFactorsLib;

for(int i = 1; i < 50; i++)
{
    Console.WriteLine($"The factors of the number {i} are: {PrimeFactors(i)}");
}