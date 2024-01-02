// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

object height = 1.32;
object name =  "amir";
Console.WriteLine($"{name} is {height} metres tall");

//int length1 = name.Lenght/**/;
int lenght2 = ((string)name).Length;
Console.WriteLine($"{name} has {lenght2} characters");
dynamic something;
// Storing an array of int values in a dynamic object.
// An array of any type has a Length property.
something = new[] { 3, 5, 7 };
// Storing an int in a dynamic object.
// int does not have a Length property.
something = 12;
// Storing a string in a dynamic object.
// string has a Length property.
something = "Ahmed";
// This compiles but might throw an exception at run-time.
Console.WriteLine($"The length of something is {something.Length}");
// Output the type of the something variable.
Console.WriteLine($"something is a {something.GetType()}");


dynamic[] javascript =  { 1,"fhdj",3.293 };

foreach (dynamic a in javascript)
{
    Console.WriteLine(a.ToString());
}
