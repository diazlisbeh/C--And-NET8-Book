string city = "London";
WriteLine($"{city} is {city.Length} characters long.");
WriteLine($"First char is {city[0]} and fourth is {city[3]}.");

string fullName = "Lisbeth Diaz";
int indexSpace = fullName.IndexOf(' ');
string firstName = fullName.Substring(0, indexSpace);
string lastName = fullName.Substring(indexSpace + 1);
WriteLine($"{lastName} {firstName}");

string company = "Microsoft";
WriteLine($"Text: {company}");
WriteLine("Starts with M: {0}, contains an N: {1}",
  arg0: company.StartsWith("M"),
  arg1: company.Contains("N"));

