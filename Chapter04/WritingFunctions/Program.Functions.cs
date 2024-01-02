﻿
using System.Globalization;

partial class Program
{
    static void TimesTable(byte number, byte size = 12)
    {
        for(int row = 0; row <= size; row++)
        {
            WriteLine($"{number} x {row} = {row*number}");
        }
    }

    static decimal CalculateTax(decimal tax, string twoLettersRegionCode)
    {
        decimal rate = twoLettersRegionCode switch
        {
            "CH" => 0.08M, // Switzerland
            "DK" or "NO" => 0.25M, // Denmark, Norway  
            "GB" or "FR" => 0.2M, // UK, France
            "HU" => 0.27M, // Hungary
            "OR" or "AK" or "MT" => 0.0M, // Oregon, Alaska, Montana
            "ND" or "WI" or "ME" or "VA" => 0.05M,
            "CA" => 0.0825M, // California
            _ => 0.06M // Most other states.
        };
        return rate * tax;
    }
    static void ConfigureCulture(string culture = "en-US", bool useComputerCulture = false) {
        
        OutputEncoding = System.Text.Encoding.UTF8;
        if(!useComputerCulture)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);
        }
        WriteLine($"Current Culture: {CultureInfo.CurrentCulture.DisplayName}");
    }
    static string CardinalToOrdinal(uint number)
    {
        uint lastTwoDigits = number % 100;
        switch (lastTwoDigits)
        {
            case 11: // Special cases for 11th to 13th.
            case 12:
            case 13:
                return $"{number:N0}th";
            default:
                uint lastDigit = number % 10;
                string suffix = lastDigit switch
                {
                    1 => "st",
                    2 => "nd",
                    3 => "rd",
                    _ => "th"
                };
                return $"{number:N0}{suffix}";
        }
    }


    /// <summary>
    /// Pass a 32-integer calculate the Factorial.
    /// </summary>
    /// <param name="number"></param>
    /// <returns> A Factorial of the number given</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    static int Factorial(int number)
    {
        if(number < 0)
        {
            throw new ArgumentOutOfRangeException($"The factorial function is defined for non-negative integers only. Input: {number}");
        }
        else if(number == 0){
            return 1;

        }
        else
        {
            checked // for overflow
            {
                return number * Factorial(number - 1);
            }
        }
    }

    static void RunFactorial()
    {
        for (int i = 1; i <= 15; i++)
        {
            try
            {
                WriteLine($"{i}! = {Factorial(i):N0}");
            }
            catch(OverflowException)
            {
                WriteLine($"{i} is too big for a 32-bit integer");
            }
            catch (Exception e)
            {
                WriteLine($"{i}! throws {e.GetType()}: {e.Message}");
            }
        }
    }

    static int FibImperactive(uint term)
    {
        if (term == 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        else if (term == 1) { return 0; }
        else if (term == 2) { return 1; }
        else { return FibImperactive(term - 1) + FibImperactive(term); }
    }

    static void RunFibImperactive()
    {
        for (uint i = 1; i <= 30; i++) {
            WriteLine("The {0} term of the Fibonacci sequence is {1:N0}.",
             arg0: CardinalToOrdinal(i),
             arg1: FibImperactive(term: i));
        }
    }

    static int FibFunctional(uint term) => term switch
    {
        0 => throw new ArgumentOutOfRangeException(),
        1 => 0,
        2 => 1,
        _ => FibFunctional(term - 1) + FibFunctional(term - 2)
    };
    static void RunFibFunctional()
    {
        for (uint i = 1; i <= 30; i++) {
            WriteLine("The {0} term of the Fibonacci sequence is {1:N0}.",
             arg0: CardinalToOrdinal(i),
             arg1: FibFunctional(term: i));
        }
    }



}
