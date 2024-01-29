

using Microsoft.EntityFrameworkCore;
using Northwind.EntityModels;
using WorkingWithEFCore;

using Microsoft.EntityFrameworkCore.ChangeTracking;

partial class Program
{
    private static void QueryingCategories()
    {
        using NorthwindDb db = new();
        SectionTitle("Categories and how many products they have");

        IQueryable<Category>? categories;
        // IQueryable<Category>? categories = db.Categories;//.Include(categories => categories.Products);
        db.ChangeTracker.LazyLoadingEnabled = false;
        Write("Enable eager loading? (Y/N): ");
        bool eagerLoading = (ReadKey().Key == ConsoleKey.Y);
        bool explicitLoading = false;
        WriteLine();
        if (eagerLoading)
        {
            categories = db.Categories?.Include(c => c.Products);
        }
        else
        {
            categories = db.Categories;
            Write("Enable explicit loading? (Y/N): ");
            explicitLoading = (ReadKey().Key == ConsoleKey.Y);
            WriteLine();
        }



        if (categories is null)
        {
            Fail("No categories Found");
            return;
        }
        foreach(Category c in categories)
        {
        if(explicitLoading)
        {
            Write($"Explicitly load products for {c.CategoryName}? (Y/N): ");
            ConsoleKeyInfo key = ReadKey();
            WriteLine();
            if(key.Key == ConsoleKey.Y)
                {
                    CollectionEntry<Category, Product> products = db.Entry(c).Collection(c2 => c2.Products);
                    if(!products.IsLoaded) { products.Load(); }
                }
        }
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

        IQueryable<Category>? categories = db.Categories?.TagWith("Products filtered by price and sorted")
            .Include(p => p.Products.Where(p => p.Cost <= minimunStockPrice));

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

    public static void QueringOneProduct()
    {
        using NorthwindDb db = new();

        SectionTitle("Queryng one product");
        int productId;
        string prompt;

        do{
            WriteLine("Write the product Id");
            prompt = ReadLine();
        }while(!int.TryParse(prompt, out productId));

        Product? product = db.Products?.First(p => p.ProductId == productId);
        Info($"With First {product.ProductName} was Found");
        if(product is null){
            Fail("Not product Found with First");
        }
        product = db.Products?.Single(p => p.ProductId == productId);
        Info($"With Single {product.ProductName} was Found");
        if(product is null){
            Fail("Not product Found with Single");
        }
    }

    public static void QueryngWithLike()
    {
         using NorthwindDb db = new();

        SectionTitle("Queryng with Like");
        string input = ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Fail("You did not enter part of a product name.");
            return;
        }
        IQueryable<Product>? products = db.Products?
            .Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));
        if (products is null || !products.Any())
        {
            Fail("No products found.");
            return;
        }
        foreach (Product p in products)
        {
            WriteLine("{0} has {0} units in stock. Discontinued: {0}", 
                p.ProductName);
        }

        
    }
    private static void GetRandomProduct()
    {
        using NorthwindDb db = new();
        SectionTitle("Get a random product");
        int? rowCount = db.Products?.Count();
        if (rowCount is null)
        {
            Fail("Products table is empty.");
            return;
        }
        Product? p = db.Products?.FirstOrDefault(
            p => p.ProductId == (int)(EF.Functions.Random() * rowCount));
        if (p is null)
        {
            Fail("Product not found.");
            return;
        }
        WriteLine($"Random product: {p.ProductId} - {p.ProductName}");
    }

    private static void LazyLoadingWithNoTracking()
    {
        using NorthwindDb db = new();
        SectionTitle("Lazy-loading with no tracking");
        IQueryable<Product>? products = db.Products?.AsNoTracking();
        if (products is null || !products.Any())
        {
            Fail("No products found.");
            return;
        }
        foreach (Product p in products)
        {
            WriteLine("{0} is in category named {1}.",
              p.ProductName, p.Category.CategoryName);
        }
    }


}