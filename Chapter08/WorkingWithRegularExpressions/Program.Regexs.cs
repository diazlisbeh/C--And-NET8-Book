using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

    partial class Program
    {
    [GeneratedRegex(DigitsOnlyText, RegexOptions.IgnoreCase)]
    public static partial Regex DigitsOnly();
    [GeneratedRegex(CommaSeparatorText, RegexOptions.IgnoreCase)]
    public static partial Regex CommaSeparator();
    }
