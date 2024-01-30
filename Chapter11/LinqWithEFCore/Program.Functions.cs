using Northwind.EntityModels; // To use NorthwindDb, Category, Product.
using Microsoft.EntityFrameworkCore; // To use DbSet<T>.
partial class Program
{
    private static void FilterAndSort()
    {
        SectionTitle("Filter and sort");
        using NorthwindDb db = new();

        DbSet<Product> allProducts = db.Products;

        IQueryable<Product> filteredProducts =
          allProducts.Where(product => product.UnitPrice < 10M);
        IOrderedQueryable<Product> sortedAndFilteredProducts =
          filteredProducts.OrderByDescending(product => product.UnitPrice);
        WriteLine("Products that cost less than $10:");
        foreach (Product p in sortedAndFilteredProducts)
        {
            WriteLine("{0}: {1} costs {2:$#,##0.00}",
              p.ProductId, p.ProductName, p.UnitPrice);
        }
        WriteLine();
    }
    private static void AggregateProducts()
    {
        SectionTitle("Aggregate products");
        using NorthwindDb db = new();
        // Try to get an efficient count from EF Core DbSet<T>.
        if (db.Products.TryGetNonEnumeratedCount(out int countDbSet))
        {
            WriteLine($"{"Product count from DbSet:",-25} {countDbSet,10}");
        }
        else
        {
            WriteLine("Products DbSet does not have a Count property.");
        }
        // Try to get an efficient count from a List<T>.
        List<Product> products = db.Products.ToList();
        if (products.TryGetNonEnumeratedCount(out int countList))
        {
            WriteLine($"{"Product count from list:",-25} {countList,10}");
        }
        else
        {
            WriteLine("Products list does not have a Count property.");
        }
        WriteLine($"{"Product count:",-25} {db.Products.Count(),10}");
        WriteLine($"{"Discontinued product count:",-27} {db.Products
          .Count(product => product.Discontinued),8}");
        WriteLine($"{"Highest product price:",-25} {db.Products
          .Max(p => p.UnitPrice),10:$#,##0.00}");
        WriteLine($"{"Sum of units in stock:",-25} {db.Products
          .Sum(p => p.UnitsInStock),10:N0}");
        WriteLine($"{"Sum of units on order:",-25} {db.Products
          .Sum(p => p.UnitsOnOrder),10:N0}");
        WriteLine($"{"Average unit price:",-25} {db.Products
          .Average(p => p.UnitPrice),10:$#,##0.00}");
        WriteLine($"{"Value of units in stock:",-25} {db.Products
          .Sum(p => p.UnitPrice * p.UnitsInStock),10:$#,##0.00}");
    }

    private static void OutputTableOfProducts(Product[] products,
  int currentPage, int totalPages)
    {
        string line = new('-', count: 73);
        string lineHalf = new('-', count: 30);
        WriteLine(line);
        WriteLine("{0,4} {1,-40} {2,12} {3,-15}",
          "ID", "Product Name", "Unit Price", "Discontinued");
        WriteLine(line);
        foreach (Product p in products)
        {
            WriteLine("{0,4} {1,-40} {2,12:C} {3,-15}",
              p.ProductId, p.ProductName, p.UnitPrice, p.Discontinued);
        }
        WriteLine("{0} Page {1} of {2} {3}",
          lineHalf, currentPage + 1, totalPages + 1, lineHalf);
    }

    private static void OutputPageOfProducts(Product[] products, int currentPage, int totalPages, int pagesSize)
    {
        var pagquery = products.OrderBy(p => p.ProductId).Skip(pagesSize * pagesSize).Take(pagesSize);

        Clear(); // Clear the console/screen.
        SectionTitle(title: pagquery.ToQueryString());
        OutputTableOfProducts(pagquery.ToArray(),
          currentPage, totalPages);

    }

}
