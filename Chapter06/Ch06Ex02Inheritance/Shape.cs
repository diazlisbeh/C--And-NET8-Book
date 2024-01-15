using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch06Ex02Inheritance;
public class Shape
{
    public double Height{ get; set; }
    public double Width{ get; set; }
    public virtual double Area()
    {
        return Height * Width;
    }
}
