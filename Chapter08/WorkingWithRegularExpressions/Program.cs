using System.Text.RegularExpressions;

WriteLine("Enter your Age");
string age = ReadLine()!;
Regex r = DigitsOnly();
WriteLine(r.IsMatch(age) ? "Thank You" : "Tu string no sirve");