using Packt.Shared;

ConfigureConsole();

Person bob = new Person();
bob.Name = "Bob";
bob.FavoriteAncientWonder = WondersOfTheAncientWorld.GreatPyramidOfGiza;

bob.GetOrigin();

bob.SayHello();
bob.SayHello("lixxx");
WriteLine(bob);

int a = 10; 
int b = 20; 
int c = 30;
int d = 40;
WriteLine($"Before: a={a}, b={b}, c={c}, d={d}"); 
bob.PassingParameters(a, b, ref c, out d);
WriteLine($"After: a={a}, b={b}, c={c}, d={d}");


WriteLine(bob.GetFruit().Item2);