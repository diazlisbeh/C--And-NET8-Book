using Microsoft.EntityFrameworkCore.ChangeTracking; // To use EntityEntry<T>.
using Northwind.EntityModels; // To use Customer.
using Microsoft.Extensions.Caching.Memory; // To use IMemoryCache.
using Microsoft.EntityFrameworkCore; // To use ToArrayAsync.

namespace Northwind.WebApi.Repositories;
public class CustomerRepository : ICustomerRepository
{
    private readonly IMemoryCache _memoryCache;
    private readonly MemoryCacheEntryOptions _cacheEntryOptions = new ()
    {
        SlidingExpiration = TimeSpan.FromMinutes(30)
    };
    private NorthwindContext _db;

    public CustomerRepository(NorthwindContext db, IMemoryCache memoryCache)
    {
        _db = db;
        _memoryCache = memoryCache;
    }

    public async Task<Customer?> CreateAsync (Customer c)
    {
        c.CustomerId = c.CustomerId.ToUpper();
        EntityEntry<Customer> added = await _db.Customer.AddAsync(c);
        int affected = await _db.SaveChangesAsync();
        if (affected == 1)
        {
            _memoryCache.Set(c.CustomerId,_cacheEntryOptions);
            return c;
        }
        return null;
    }
}