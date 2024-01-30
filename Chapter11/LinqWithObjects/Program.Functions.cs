

using System.Data;

partial class Program
{
    private static void DeferredExecution(string[] names)
    {
        SectionTitle("Deferred execution");

        var query1 = names.Where(name => name.EndsWith("m"));

        var query2 = from name in names where name.EndsWith("m") select name;

        string[] result1 = query1.ToArray();

        List<string> result2 = query2.ToList(); 

        foreach (string s in result1)
        {
            WriteLine(s);
            

        }
    }

    private static void FilteringUsingWhere(string[] names)
    {
        var query = names.Where(NameLongerThanFour);
        foreach (string item in query)
        {
            WriteLine(item);
        }

    }
    static bool NameLongerThanFour(string name)
    {
        // Returns true for a name longer than four characters.
        return name.Length > 4;
    }

}