partial class Program
{
    public static void OutputCollection<T>(string title, IEnumerable<T> items)
    {
        WriteLine(title);
        foreach (var item in items)
        {
            WriteLine(item);
        }
    }
}
