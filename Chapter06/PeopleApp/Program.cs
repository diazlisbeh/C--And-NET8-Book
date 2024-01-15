using Packt.Shared;

Person harry = new()
{
    Name = "Harry",
    Born = new(year: 2001, month: 3, day: 25,
    hour: 0, minute: 0, second: 0,
    offset: TimeSpan.Zero)
};
harry.WriteToConsole();

// Implementing functionality using methods.
Person lamech = new() { Name = "Lamech" };
Person adah = new() { Name = "Adah" };
Person zillah = new() { Name = "Zillah" };
// Call the instance method to marry Lamech and Adah.
lamech.Marry(adah);
// Call the static method to marry Lamech and Zillah.
Person.Marry(lamech, zillah);
lamech.OutputSpouses();
adah.OutputSpouses();
zillah.OutputSpouses();
// Call the instance method to make a baby.
Person baby1 = lamech.ProcreateWith(adah);
baby1.Name = "Jabal";
WriteLine($"{baby1.Name} was born on {baby1.Born}");
// Call the static method to make a baby.
Person baby2 = Person.Procreate(zillah, lamech);
baby2.Name = "Tubalcain";
adah.WriteChildrenToConsole();
zillah.WriteChildrenToConsole();
lamech.WriteChildrenToConsole();
for (int i = 0; i < lamech.Children.Count; i++)
{
    WriteLine(format: "  {0}'s child #{1} is named \"{2}\".",
      arg0: lamech.Name, arg1: i,
      arg2: lamech.Children[i].Name);
}

harry.OutputSpouces();
lamech.OutputSpouces();

harry.Shout += Harry_Shout;
harry.Shout += Harry_Stop;
harry.Poke();
harry.Poke();
harry.Poke();
harry.Poke();
harry.Poke();

Person?[] people =
{
  null,
  new() { Name = "Simon" },
  new() { Name = "Jenny" },
  new() { Name = "Adam" },
  new() { Name = null },
  new() { Name = "Richard" }
};
OutputPeopleName(people, "Initial list of people:");
Array.Sort(people);
OutputPeopleName(people,
  "After sorting using Person's IComparable implementation:");

Array.Sort(people,new PersonComparer());
OutputPeopleName(people, "After Person's IComparer");

WriteLine();
WriteLine("Equelity of types");
WriteLine();

int a = 3;
int b = 3;
WriteLine($"a: {a}, b: {b}");
WriteLine($"a == b: {a == b}");

Person p1 = new() { Name = "Kevin"};
Person p2 = new() { Name = "Kevin"};
Person p3 = p2;
WriteLine($"a: {p1}, b: {p2}");
WriteLine($"a Name: {p1.Name}, b: {p2.Name}");
WriteLine($"p3 == p2: {p3 == p2}");


#region Defining struct types

DisplacementVector vector1 = new(2, 5);
DisplacementVector vector2 = new(2, 5);
DisplacementVector vector3 = vector1 + vector2;
WriteLine($"({vector1.X},{vector1.Y}) + ({vector2.X},{vector2.Y}) = ({vector3.X},{vector3.Y})");

DisplacementVector vector4 = new(2, 5);
WriteLine($"vector 1 igual a vetor 4: {vector1.Equals(vector4)}");
WriteLine($"vector1 == vector4: {vector1 == vector4}");
#endregion

#region Inheriting from classes

Employee john = new()
{
    Name = "John Jones",
    Born = new(year: 1990, month: 7, day: 28,
    hour: 0, minute: 0, second: 0, offset: TimeSpan.Zero)
};
john.WriteToConsole();


#endregion

try
{
    john.TimeTravel(when: new(1999, 12, 31));
    john.TimeTravel(when: new(1950, 12, 25));
}
catch (PersonException ex)
{
    WriteLine(ex.Message);
}
#region Mutability
C1 c1 = new() { Name = "Bob" };
c1.Name = "Bill";
C2 c2 = new(Name: "Bob");
//c2.Name = "Bill"; // CS8852: Init-only property.
S1 s1 = new() { Name = "Bob" };
s1.Name = "Bill";
S2 s2 = new(Name: "Bob");
s2.Name = "Bill";
S3 s3 = new(Name: "Bob");
//s3.Name = "Bill"; // CS8852: Init-only property.

#endregion
