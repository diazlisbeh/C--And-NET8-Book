
using NullHandling;

int thisConnotBeNull = 4;
//thisConnotBeNull = null;
WriteLine(thisConnotBeNull);
int? thisCoulBeNull = null;
WriteLine(thisCoulBeNull); 
WriteLine(thisCoulBeNull.GetValueOrDefault());
thisCoulBeNull = 7;
WriteLine(thisCoulBeNull); 
WriteLine(thisCoulBeNull.GetValueOrDefault());
Address address = new(city: "London")
{
    Building = null,
    Street = null!,
    Region = "UK"
};
//WriteLine(address.Building.Length);
if (address.Street is not null)
{
    WriteLine(address.Street.Length);
}

if (address.Street is not null) { WriteLine(address.Street.Length); }

