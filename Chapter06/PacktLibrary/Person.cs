using System.Numerics;
using System.Security.Cryptography;
using System.Threading;

namespace Packt.Shared;
public class Person : IComparable<Person>
{
    #region Properties

    public string? Name { get; set; }
    public DateTimeOffset Born {  get; set; }
    public bool Married => Spouses.Count > 0;
    public List<Person> Children = new();
    public List<Person> Spouses = new();

    #endregion
    #region Methods

    public void WriteToConsole()
    {
        WriteLine($"{Name} was born on a {Born:dddd}");
    }
    public void WriteChildrenToConsole()
    {
        string term = Children.Count == 1 ? "child" : "children";
        WriteLine($"{Name} has {Children.Count} {term}");
    }
    public static void Marry(Person p1, Person p2)
    {
        ArgumentNullException.ThrowIfNull(p1);
        ArgumentNullException.ThrowIfNull(p2);
        if(p1.Spouses.Contains(p2) || p2.Spouses.Contains(p1) )
        {
            throw new ArgumentException(string.Format("{0} is already married to {1}"));
        }
        p1.Spouses.Add(p2);
        p2.Spouses.Add(p1);
    }
    public void Marry(Person partner)
    {
        Marry(this,partner);
    }
    public void OutputSpouses()
    {
        if (Married)
        {
            string term = Spouses.Count == 1 ? "person" : "people";
            WriteLine($"{Name} is married to {Spouses.Count} {term}:");
            foreach (Person spouse in Spouses)
            {
                WriteLine($"  {spouse.Name}");
            }
        }
        else
        {
            WriteLine($"{Name} is a singleton.");
        }
    }
    public static Person Procreate(Person p1,Person p2, string name = "ramdom baby")
    {
        ArgumentNullException.ThrowIfNull(p1);
        ArgumentNullException.ThrowIfNull(p2);
        if(!p1.Spouses.Contains(p2) && !p2.Spouses.Contains(p1) )
        {
            throw new ArgumentException(string.Format("{0} and {1} must be married to procreate"));
        }
        Person baby = new()
        {
            Name = name,
            Born = DateTimeOffset.Now
        };
        p1.Children.Add(baby);
        p2.Children.Add(baby);
        return baby;
    }

    public Person ProcreateWith(Person parther)
    {
        return Procreate(this,parther);
    }
    public void OutputSpouces()
    {
        if (Married)
        {
            string term = Spouses.Count > 1 ? "people" : "person";
            WriteLine($"{Name} is married with {Spouses.Count} {term}:");
            foreach(Person spouse in Spouses)
            {
                WriteLine($"  {spouse.Name}");
            }

        }
        else
        {
            WriteLine($"{Name} is a siglenton");
        }
    }

    public static bool operator + (Person p1, Person p2)
    {
        Marry(p1, p2);
        return p1.Married && p2.Married;
    }
    public static Person operator *(Person p1, Person p2)
    {
        return Procreate(p1, p2);

    }
    #endregion

    #region Events

    public event EventHandler? Shout;
    public int AngryLevel;

    public void Poke()
    {
        AngryLevel++;
        if (AngryLevel < 3) return;

        if(Shout is not null)
        {
            Shout(this,EventArgs.Empty);
        }
    }

    public int CompareTo(Person? other)
    {
        throw new NotImplementedException();
    }
    #endregion

}