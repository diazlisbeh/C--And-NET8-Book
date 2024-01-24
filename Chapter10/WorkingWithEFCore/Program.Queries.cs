

partial class Program
{
    private static void QueryingCategories()
    {
        using NorthwindDb db = new();
        SectionTitle("Categories and how many products they have");

        IQueryable<Category>? categories = db.Categories?.include(categories => categories.Products);

        if(categories is null || !categories.Any())
        {
            Fail("No categories Found");
            return;
        }
        foreach(Category c in categories)
        {
            WriteLine($"{c.CategoryName} has {c.Producus.Count} products");
        }
    }
}