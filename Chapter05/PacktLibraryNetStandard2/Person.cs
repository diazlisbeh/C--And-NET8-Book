using System;
using System.Collections.Generic;
using System.Text;

namespace Packt.Shared;

public class Person
{
#region Fields
  public string? Name;
    public string? HomePlanet = "Earth";
  public DateTime Born;
  public WondersOfTheAncientWorld FavoriteAncientWonder;

    #endregion

    #region Methods: Actions the type can perform

    public void WriteToConsole()
    {
        WriteLine($"{Name} was Born on a {Born:dddd}");
    }
    public void GetOrigin()
    {
        WriteLine($"{Name} was Born on  {HomePlanet}");
    }
    #endregion

    #region Parameter Obverloagin
    public void SayHello(){
      WriteLine("HOlaaa tu");
    }
    public void SayHello(string name){
      WriteLine($"HOlaaa {name}");
    }
    #endregion

    #region Optional Parameters
    public string OptionalParameters(int count, string command = "Run!",double number = 0.0, bool active = true)
    {
      return $"{command}, {number}, {active}, {count}";
    }

    #endregion

    public void PassingParameters(int w, in int x, ref int y, out int z){

      // out parameters cannot have a default and they must be initialized inside the method
      z = 100;
      // x++ Compilid error
      y++;
      z++;
      WriteLine($"In the method:w={w}, x={x}, y={y}, z={z} ");
    }

    public (string,int) GetFruit(){
      return ("Apples",5);
    }

}


