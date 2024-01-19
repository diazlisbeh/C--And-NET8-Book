using StringDictionaries = System.Collections.Generic.Dictionary<string, string>;

List<string> cities = new();
cities.Add("Santiago");
cities.Add("Londres");
cities.Add("New york");

OutputCollection("Initial Collection", cities);

StringDictionaries keywords = new ();
keywords.Add(key: "int", value: "32-bit integer data type");
// Add using positional parameters.
keywords.Add("long", "64-bit integer data type");
keywords.Add("float", "Single precision floating point number");
/* Alternative syntax; compiler converts this to calls to Add method.
Dictionary<string, string> keywords = new()
{
  { "int", "32-bit integer data type" },
  { "long", "64-bit integer data type" },
  { "float", "Single precision floating point number" },
}; */
/* Alternative syntax; compiler converts this to calls to Add method.
Dictionary<string, string> keywords = new()
{
  ["int"] = "32-bit integer data type",
  ["long"] = "64-bit integer data type",
  ["float"] = "Single precision floating point number",
}; */
OutputCollection("Dictionary keys", keywords.Keys);
OutputCollection("Dictionary values", keywords.Values);
WriteLine("Keywords and their definitions:");
foreach (KeyValuePair<string, string> item in keywords)
{
    WriteLine($"  {item.Key}: {item.Value}");
}
// Look up a value using a key.
string key = "long";
WriteLine($"The definition of {key} is {keywords[key]}.");


HashSet<string> keys = new();

foreach(string name in new[] { "Holas", "Lis", "Jose" })
{
    bool added = keys.Add(name);
    WriteLine($"The key {name} added: {added}");
}