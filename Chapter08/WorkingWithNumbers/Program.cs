using System.Numerics;
#region Large numbers
const int width = 40;
WriteLine("ulong.MaxValue vs 30-digit BigInteger");
WriteLine(new string('-', width));

ulong big = ulong.MaxValue;
WriteLine($"{big,width:N0}");
BigInteger bigger = BigInteger.Parse("123456789012345678901234567890");
WriteLine($"{bigger,width:N0}");
#endregion

#region Complex Numbers
Complex c1 = new(real: 4, imaginary: 2);
Complex c2 = new(real: 8, imaginary: 1);
Complex c3 = c1 + c2;

WriteLine($"{c1} added to {c2} is {c3}");

WriteLine("{0} + {1}i added to {2} + {3}i is {4} + {5}i",
    c1.Real,c1.Imaginary,
    c2.Real,c2.Imaginary,
    c3.Real,c3.Imaginary
    );
#endregion
