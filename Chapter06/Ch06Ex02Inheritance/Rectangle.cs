using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch06Ex02Inheritance
{
    public class Rectangle : Shape
    {
        public Rectangle(double height, double width) 
        {
            Height = height;
            Width = width;
        }
    }
}
