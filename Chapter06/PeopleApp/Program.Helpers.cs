using Packt.Shared;
    partial class Program
    {
        private static void OutputPeopleName(IEnumerable<Person> people, string tittle)
        {
            WriteLine(tittle);
            foreach (var person in people) {
            WriteLine("{0}", person is null ? "<null> Person" : person.Name ?? "<Null> Person");
             }
        }
    }

