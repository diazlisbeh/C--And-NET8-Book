using Packt.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



     partial  class Program
    {
        private static void Harry_Shout(object? sender, EventArgs e)
        {
            if (sender == null) return;
            if(sender is not Person p) return;
            WriteLine($"{p.Name} is Angry with this level {p.AngryLevel}");
        }
        private static void Harry_Stop(object? sender, EventArgs e)
    {
        WriteLine("Holaaaa");

    }
}

