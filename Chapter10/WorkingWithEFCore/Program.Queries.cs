

using Microsoft.EntityFrameworkCore;
using Northwind.EntityModels;
using WorkingWithEFCore;

partial class Program
{
    private static void QueryingCategories()
    {
        using NorthwindDb db = new();
        SectionTitle("Categories and how many products they have");

        IQueryable<Category>? categories = db.Categories?.Include(categories => categories.Products);

        if(categories is null)
        {
            Fail("No categories Found");
            return;
        }
        foreach(Category c in categories)
        {
            WriteLine($"{c.CategoryName} has {c.Products.Count} products");
        }
        Info($"ToQueryString: {categories.ToQueryString()}");

    }

    private static void FilteredIncludes()
    {
        using NorthwindDb db = new();
        string input;
        int minimunStockPrice;
        do
        {
            WriteLine("Enter the minimun values of units in stock");
            input = ReadLine();

        }
        while (!int.TryParse(input, out minimunStockPrice));        

        IQueryable<Category>? categories = db.Categories?.Include(p => p.Products.Where(p => p.Cost <= minimunStockPrice));

        if(categories is null)
        {
            Fail("NO categories found");
        }

        foreach(Category c in categories)
        {
            WriteLine($"The category {c.CategoryName} has price {c.Products.Count}");
            foreach(Product p in c.Products)
            {
                WriteLine($"The {p.ProductName} has {p.Cost} in Stock");
            }
        }

    }

    private static void QueryingProducts()
    {
        using NorthwindDb db = new();
        string input;
        int stockPrice;
        do
        {
            WriteLine("Enter the minimun values of units in stock");
            input = ReadLine();

        }
        while (!int.TryParse(input, out stockPrice));        

        IQueryable<Product> products = db.Products?.Where(p => p.Cost >= stockPrice).OrderByDescending(p => p.Cost);

        if(products is null)
        {
            Fail("No hay nah");
            return;
        }

        foreach (Product p in products)
        {
            WriteLine(
              "{0}: {1} costs {2:$#,##0.00} and has {3} in stock.",
              p.ProductId, p.ProductName, p.Cost, p.Cost);
        }





    }
}