using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullHandling
{
    public class Address
    {
        public string? Building { get; set; }
        public string Street{ get; set; } = string.Empty;
        public string City{ get; set; }
        public string Region{ get; set; }

        public Address()
        {
            City = string.Empty;
            Region = string.Empty;
        }
        public Address(string? city) : this()
        {
            City = city;
        }
    }
}
