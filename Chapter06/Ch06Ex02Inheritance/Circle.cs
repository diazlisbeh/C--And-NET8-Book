using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch06Ex02Inheritance
{
    public class Circle: Shape
    {
        public double Radio{ get; set; }
        public Circle(double radius ) {
         Radio = radius;
        }
        public override double Area()
        {
            return (Math.PI *Math.Pow(Radio,2));
        }
    }
}
