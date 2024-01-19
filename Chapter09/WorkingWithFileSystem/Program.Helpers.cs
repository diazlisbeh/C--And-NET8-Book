using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

partial class Program
{
    private static void SectionTitle(string title)
    {
        WriteLine();
        ConsoleColor previusColor = ForegroundColor;
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine($"***{title}***");
        ForegroundColor = previusColor;

    }
}
