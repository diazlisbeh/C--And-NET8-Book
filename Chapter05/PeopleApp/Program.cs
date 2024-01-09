using Packt.Shared;
using PacktLibraryModern;

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

Passenger[] passengers = {
  new FirstClassPassenger { AirMiles = 1_419, Name = "Suman" },
  new FirstClassPassenger { AirMiles = 16_562, Name = "Lucy" },
  new BusinessClassPassenger { Name = "Janice" },
  new CoachClassPassenger { CarryOnKG = 25.7, Name = "Dave" },
  new CoachClassPassenger { CarryOnKG = 0, Name = "Amit" }
};

foreach(Passenger pass in passengers){
    decimal flighCost = pass switch
    {
        FirstClassPassenger p when p.AirMiles > 35_000 => 1_500M,
        FirstClassPassenger p when p.AirMiles > 15_000 => 1_750M,
         FirstClassPassenger _                         => 2_000M,
    BusinessClassPassenger _                      => 1_000M,
    CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M, 
    CoachClassPassenger _                         => 650M,
    _                                             => 800M
  };
  WriteLine($"Flight costs {flighCost:C} for {pass}");
    }


ImmutablePerson person = new(){
  FirstName = "Jeff",
  LastName = "Sanchez"
};

// person.FirstName = "jose";

ImmutableVehicle car = new()
{
  Brand = "Kia",
  Color = "Blue",
  Wheels = 4
};

ImmutableVehicle repaintedCar = car with {Color = "red"};
WriteLine($"Original car color was {car.Color}.");
WriteLine($"New car color is {repaintedCar.Color}.");


AnimalClass arc1 = new(){Name="Rex"};
AnimalClass arc2 = new(){Name="Rex"};
WriteLine($"arc1 == arc2: {arc1 == arc2}");
AnimalRecord arr1 = new(){Name="Rex"};
AnimalRecord arr2 = new(){Name="Rexjfdks"};
WriteLine($"arc1 == arc2: {arr1 == arr2}");


ImmutableAnimal oscar = new("Oscar", "perro");
var (who,what) = oscar;
WriteLine($"{who} is a {what}");

HeadSet cp = new ("Nokia", "A10238");
WriteLine(cp.ProductName, cp.Manufacturer);