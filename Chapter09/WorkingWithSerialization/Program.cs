using System.Xml.Serialization;
using Packt.Shared;
using FastJson = System.Text.Json.JsonSerializer;
List<Person> people = new()
{
  new(initialSalary: 30_000M)
  {
    FirstName = "Alice",
    LastName = "Smith",
    DateOfBirth = new(year: 1974, month: 3, day: 14)
  },
  new(initialSalary: 40_000M)
  {
    FirstName = "Bob",
    LastName = "Jones",
    DateOfBirth = new(year: 1969, month: 11, day: 23)
  },
  new(initialSalary: 20_000M)
  {
    FirstName = "Charlie",
    LastName = "Cox",
    DateOfBirth = new(year: 1984, month: 5, day: 4),
    Children = new()
    {
      new(initialSalary: 0M)
      {
        FirstName = "Sally",
        LastName = "Cox",
        DateOfBirth = new(year: 2012, month: 7, day: 12)
      }
    }
  }
};
SectionTitle("Serializing as XML");

XmlSerializer xs = new(people.GetType());

string path = Combine(CurrentDirectory, "people.xml");
using (FileStream stream = File.Create(path))
{
    xs.Serialize(stream, people);
}
OutputFileInfo(path);


#region Deserializjing XML files
SectionTitle("Desiralizing XML files");

using(FileStream xmlLoad = File.Open(path, FileMode.Open))
{
    List<Person>? loadedPeople = xs.Deserialize(xmlLoad) as List<Person>;
    if(loadedPeople != null)
    {
        foreach(Person person in loadedPeople)
        {
            WriteLine (person.FirstName, person.LastName);  
        }
    }
}
#endregion

#region JSON Serialization
SectionTitle("Serializing with JSON");

string jsongPath = Combine(CurrentDirectory, "people.json");
using(StreamWriter sw = File.CreateText(jsongPath))
{
    Newtonsoft.Json.JsonSerializer jss = new();
    jss.Serialize(sw, people);  
}
OutputFileInfo(jsongPath);

#endregion



#region Deserialized JSON
SectionTitle("Deserialize JSON");

await using(FileStream fs = File.Open(jsongPath, FileMode.Open))
{
    List<Person>? personLoaded = await FastJson.DeserializeAsync(fs,typeof(List<Person>)) as List<Person>;

    if (personLoaded is not null)
    {
        foreach (Person p in personLoaded)
        {
            WriteLine("{0} has {1} children.",
              p.LastName, p.Children?.Count ?? 0);
        }
    }
}

#endregion
