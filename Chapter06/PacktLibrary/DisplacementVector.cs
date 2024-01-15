using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.Shared;
public record struct DisplacementVector
{
    public int X{ get; set; }
    public int Y{ get; set; }
    public DisplacementVector(int x, int y)
    {
        X = x;
        Y = y;
    }
    public static DisplacementVector operator + (DisplacementVector left, DisplacementVector right)
    {
        return new DisplacementVector(left.X + right.X, right.Y + left.Y);
    }
}
