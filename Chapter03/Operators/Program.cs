
#region 
using Operators;
using System.Diagnostics.CodeAnalysis;

int a = 3;
int b = a++;
WriteLine/**/($"a is {a}, b is {b}");
#endregion

#region null coalescing operators
string? authorName = null;
int masLengt = authorName?.Length ?? 30;
authorName ??= "unknown";
WriteLine(masLengt);
WriteLine(authorName);
#endregion

#region bitwise and binary
WriteLine();
int x = 10;
int y = 6;
WriteLine($"Expression | Decimal |   Binary");
WriteLine($"-------------------------------");
WriteLine($"x          | {x,7} | {x:B8}");
WriteLine($"y          | {y,7} | {y:B8}");
WriteLine($"x & y      | {x & y,7} | {x & y:B8}");
WriteLine($"x | y      | {x | y,7} | {x | y:B8}");
WriteLine($"x ^ y      | {x ^ y,7} | {x ^ y:B8}");

WriteLine($"x << 3    | {x << 1,7} | {x << 1:B8}");
WriteLine($"x * 3     | {x * 3,7}  | {x * 3:B8}");
WriteLine($"x >> 3    | {x >> 1,7} | {x >> 1:B8}");
#endregion

#region Parttern maching

object o = 3;
int j = 4;
if(o is int i)
{
    WriteLine($"{i} x {j} = {j * i}");
}
else
{
    WriteLine("No se puede");
}

#endregion

#region Switch Cases
// Inclusive lower bound but exclusive upper bound.
int number = Random.Shared.Next(minValue: 1, maxValue: 7);
WriteLine($"My random number is {number}");
switch (number)
{
    case 1:
        WriteLine("One");
        break; // Jumps to end of switch statement.
    case 2:
        WriteLine("Two");
        goto case 1;
    case 3: // Multiple case section.
    case 4:
        WriteLine("Three or four");
        goto case 1;
    case 5:
        goto A_label;
    default:
        WriteLine("Default");
        break;
} // End of switch statement.
WriteLine("After end of switch");
A_label:
WriteLine($"After A_label");

#endregion

#region Swicth in practice
var animals = new Animal?[]
{
    new Cat {Name= "Karen", Born = new(2020, 01,12),Legs =4, IsDomestic = true},
    new Cat {Name= "Fluppy", Born = new(2020, 01,12), IsDomestic = false},
    new Spider{Name= "Peter", Born = DateTime.Today.AddDays(3),IsPoisonous= true },
    new Spider{Name= "Furry", Born = DateTime.Now,IsPoisonous= true }
};

foreach (Animal? animal in animals)
{

    string message;

    switch (animal)
    {
        case Cat fourLeggedCat when fourLeggedCat.Legs == 4:
            message = $"The cat named {fourLeggedCat.Name}";
            break;
        case Cat wildCat when wildCat.IsDomestic == false:
            message = $"Este es violento, se llama {wildCat.Name}";
            break;
        case Cat cat:
            message = $"The cat is named {cat.Name}.";
            break;
        default: // default is always evaluated last.
            message = $"{animal.Name} is a {animal.GetType().Name}.";
            break;
        case Spider spider when spider.IsPoisonous:
            message = $"The {spider.Name} spider is poisonous. Run!";
            break;
        case null:
            message = "The animal is null.";
            break;

    }
    WriteLine(message); 
}
#endregion

#region Swicth mas bacanos

foreach (Animal? animal in animals)
{
    string message;

    message = animal switch
    {
        Cat fourLeggedCat when fourLeggedCat.Legs == 4
   => $"The cat named {fourLeggedCat.Name} has four legs.",
        Cat wildCat when wildCat.IsDomestic == false
          => $"The non-domestic cat is named {wildCat.Name}.",
        Cat cat
          => $"The cat is named {cat.Name}.",
        Spider spider when spider.IsPoisonous
          => $"The {spider.Name} spider is poisonous. Run!",
        null
          => "The animal is null.",
        _// default value with _
          => $"{animal.Name} is a {animal.GetType().Name}."

    };
    WriteLine(message);
}

#endregion
WriteLine("Enumerator");
var z = animals.GetEnumerator();
WriteLine(z.MoveNext());
WriteLine(z.Current);
WriteLine(z.MoveNext());