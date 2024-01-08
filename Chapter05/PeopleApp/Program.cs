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

Passenger[] passengers = {
  new FirstClassPassenger { AirMiles = 1_419, Name = "Suman" },
  new FirstClassPassenger { AirMiles = 16_562, Name = "Lucy" },
  new BusinessClassPassenger { Name = "Janice" },
  new CoachClassPassenger { CarryOnKG = 25.7, Name = "Dave" },
  new CoachClassPassenger { CarryOnKG = 0, Name = "Amit" },
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
  WriteLine($"Flight costs {flightCost:C} for {passenger}");
    }
}